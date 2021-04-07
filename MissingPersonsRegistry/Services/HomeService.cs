using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using MissingPersonsRegistry.Data;
using MissingPersonsRegistry.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DissapearPersonsRegistry.Services
{
    public interface IHomeService 
    {
        List<Person> Index(int id);
        void Create(Person person);
        Person GetDetails(int id);
        void Edit(Person person);
         void ConfirmDelete(int id);
    }
    public class HomeService:IHomeService
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IWebHostEnvironment webHostEnvironment;

        public HomeService(ApplicationDbContext dbContext, IWebHostEnvironment webHostEnvironment)
        {
            this.dbContext = dbContext;
            this.webHostEnvironment = webHostEnvironment;
        }
        
        public List<Person> Index(int id)
        {
            List<Person> persons = new List<Person>();
            if (id == 0)
            {
                var query = dbContext
                .Persons
                .Include(p => p.DissapeerDetails)
                .Include(p => p.Sex)
                .ToList();
                persons.AddRange(query);

            }
            else
            {
                var query = dbContext
                .Persons
                .Include(p => p.DissapeerDetails)
                .Include(p => p.Sex)
                .Where(p => p.SexId == id)
                .ToList();
                persons.AddRange(query);
            }
            return persons;
        }

        public void Create(Person person)
        {
            string filePath = UploadFile(person);
            person.ImageSrc = filePath;

            dbContext.Persons.Add(person);
            dbContext.SaveChanges();

        }

        public Person GetDetails(int id)
        {
            var person = dbContext
                .Persons
                .Include(d => d.DissapeerDetails)
                .Include(d => d.Sex)
                .FirstOrDefault(p => p.Id == id);
            return person;
        }

        public void Edit(Person person)
        {
            var editedPerson = dbContext.Persons.FirstOrDefault(p => p.Id == person.Id);
            if (person.PersonImage != null)
            {
                string filePath = UploadFile(person);
                person.ImageSrc = filePath;
                DeleteFile(editedPerson.ImageSrc);
            }
            else
            {
                person.ImageSrc = editedPerson.ImageSrc;
            }
            dbContext.Entry(editedPerson).CurrentValues.SetValues(person);
            dbContext.SaveChanges();
        }
        public void ConfirmDelete(int id)
        {
            var person = dbContext.Persons.FirstOrDefault(p => p.Id == id);
            DeleteFile(person.ImageSrc);
            dbContext.Persons.Remove(person);
            dbContext.SaveChanges();

        }
        private string UploadFile(Person person)
        {
            string fileName = null;
            string filePath = "";
            if (person.PersonImage != null)
            {
                string uploadDir = Path.Combine(webHostEnvironment.WebRootPath, "images");
                string extension = Path.GetExtension(person.PersonImage.FileName);
                fileName = Guid.NewGuid().ToString() + "-" + $"{person.Name}-{person.Surname}{extension}";
                filePath = Path.Combine(uploadDir, fileName);
                using (var filestream = new FileStream(filePath, FileMode.Create))
                {
                    person.PersonImage.CopyTo(filestream);
                }
            }
            return $"~/images/{fileName}";
        }
        private void DeleteFile(string oldImgSrc)
        {
            if (oldImgSrc != null)
            {
                string oldImageSrc = this.webHostEnvironment.WebRootPath + $"\\images\\{oldImgSrc.Remove(0, 9)}";
                FileInfo file = new FileInfo(oldImageSrc);
                if (file.Exists)
                {
                    file.Delete();
                }
            }

        }
    }

   
}
