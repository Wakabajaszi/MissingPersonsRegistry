using MissingPersonsRegistry.Data;
using MissingPersonsRegistry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DissapearPersonsRegistry.Data.Seeders
{
    public class InitDataSeed
    {
        private readonly ApplicationDbContext dbContext;


        public InitDataSeed(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Seed() 
        {
            if (!dbContext.Sex.Any()) 
            {
                dbContext.Sex.AddRange(SexSeed());
                dbContext.SaveChanges();
            }
            if (!dbContext.Persons.Any())
            {
                dbContext.Persons.AddRange(PersonsSeed());
                dbContext.SaveChanges();
            }
        }

        private List<Sex> SexSeed()
        {
            List<Sex> sexes = new List<Sex>()
            {
                new Sex(){Name="Mężczyna"},
                new Sex(){Name="Kobieta"}
            };

            return sexes;

        }

        private List<Person> PersonsSeed()
        {
            List<Person> persons = new List<Person>()
            {
                new Person()
                {
                    Name="Radek",
                    Surname="Radosław",
                    DateOfBirth=DateTime.Parse("2001-04-12"),
                    Eyes="Niebieskie",
                    Hair="Blond",
                    Height=180,
                    Weight=90,
                    IdentifyingMarks = "tatuaż",
                    ImageSrc="D:\\.net\\MissingPersonsRegistry\\MissingPersonsRegistry\\wwwroot\\images\\123.jpg",
                    Nationality ="Polak",
                    SexId=1,
                    DissapeerDetails = new DissapearDetails()
                    {
                        City="Warszawa",
                        Street="Kwiatowa-11",
                        PostalCode="12-123",
                        Description="sadasdasasasasasasasasasasasasasasasasasasasasasasasasasasasdadsasd",
                        DissapeerDate = DateTime.Parse("2001-04-12 15:15:15")
                    }
                },
                new Person()
                {
                    Name="Krzyś",
                    Surname="Radosław",
                    DateOfBirth=DateTime.Parse("2001-04-12"),
                    Eyes="Niebieskie",
                    Hair="Blond",
                    Height=180,
                    Weight=90,
                    IdentifyingMarks = "tatuaż",
                    ImageSrc="D:\\.net\\MissingPersonsRegistry\\MissingPersonsRegistry\\wwwroot\\images\\123.jpg",
                    Nationality ="Polak",
                    SexId=1,
                    DissapeerDetails = new DissapearDetails()
                    {
                        City="Kraków",
                        Street="Kwiatowa-11",
                        PostalCode="12-123",
                        Description="sadasdasasasasasasasasasasasasasasasasasasasasasasasasasasasdadsasd",
                        DissapeerDate = DateTime.Parse("2003-03-22 11:16:15")
                    }
                },
                 new Person()
                {
                    Name="Kamila",
                    Surname="Kokorino",
                    DateOfBirth=DateTime.Parse("1998-04-14"),
                    Eyes="Niebieskie",
                    Hair="czarne",
                    Height=180,
                    Weight=90,
                    IdentifyingMarks = "brak",
                    ImageSrc="D:\\.net\\MissingPersonsRegistry\\MissingPersonsRegistry\\wwwroot\\images\\123.jpg",
                    Nationality ="Polka",
                    SexId=1,
                    DissapeerDetails = new DissapearDetails()
                    {
                        City="Wrocław",
                        Street="Kwiatowa-11",
                        PostalCode="12-123",
                        Description="sadasdasasasasasasasasasasasasasasasasasasasasasasasasasasasdadsasd",
                        DissapeerDate = DateTime.Parse("2003-03-22 11:16:15")
                    }
                },
            };

            return persons;

        }
    }
}
