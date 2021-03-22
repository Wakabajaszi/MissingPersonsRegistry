using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MissingPersonsRegistry.Data;
using MissingPersonsRegistry.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MissingPersonsRegistry.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext dbContext;
        private readonly IWebHostEnvironment webHostEnvironment;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext dbContext, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            this.dbContext = dbContext;
            this.webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var persons = dbContext
                .Persons
                .Include(p=>p.DissapeerDetails)
                .ToList();

            return View(persons);
        }

        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Person person)
        {
            if (!ModelState.IsValid) 
            {
                return Redirect("Home/Create");
            }
            
            string filePath = UploadFile(person);
            person.ImageSrc = filePath;
           
            dbContext.Persons.Add(person);
            dbContext.SaveChanges();

            return Redirect("Index");
        }

        public IActionResult Details(int id) 
        {
            var person = dbContext
                .Persons
                .Include(d=>d.DissapeerDetails)
                .Include(d=>d.Sex)
                .FirstOrDefault(p => p.Id == id);
            return View(person);
        }
        public IActionResult Edit(int id) 
        {
            var person = dbContext
                .Persons
                .Include(d => d.DissapeerDetails)
                .Include(d => d.Sex)
                .FirstOrDefault(p => p.Id == id);
            return View(person);
        }
        [HttpPost]
        public IActionResult Edit(Person person)
        {
            if (!ModelState.IsValid)
            {
                return Redirect("Home/Edit");
            }
            var editedPerson = dbContext.Persons.FirstOrDefault(p => p.Id == person.Id);
            
            if(person.PersonImage != null) 
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

            return RedirectToAction("Details", "Home", new { person.Id });
            
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private string UploadFile(Person person) 
        {
            string fileName = null;
            string filePath="";
            if (person.PersonImage != null) 
            {
                string uploadDir = Path.Combine(webHostEnvironment.WebRootPath, "images");
                string extension = Path.GetExtension(person.PersonImage.FileName);
                fileName = Guid.NewGuid().ToString() + "-" + $"{person.Name}-{person.Surname}{extension}";
                filePath = Path.Combine(uploadDir, fileName);
                using(var filestream = new FileStream(filePath, FileMode.Create)) 
                {
                    person.PersonImage.CopyTo(filestream);
                }
            }
            return $"~/images/{fileName}";
        }
        private void DeleteFile(string oldImgSrc) 
        {
            if(oldImgSrc != null) 
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
