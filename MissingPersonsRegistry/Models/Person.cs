using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MissingPersonsRegistry.Models
{
    public class Person
    {
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        [DisplayName("Imię")]
        public string Name { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        [DisplayName("Nazwisko")]
        public string Surname { get; set; }
        [Column(TypeName = "date")]
        [DisplayName("Data Urodzenia")]
        public DateTime DateOfBirth { get; set; }
        public int SexId { get; set; }
        public Sex Sex { get; set; }
        [DisplayName("Wzrost")]
        public int Height { get; set; }
        [DisplayName("Waga")]
        public int Weight { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [DisplayName("Kolor Włosów")]
        public string Hair { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [DisplayName("Kolor Oczu")]
        public string Eyes { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [DisplayName("Narodowość")]
        public string Nationality { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        [DisplayName("Znaki Szczególne")]
        public string IdentifyingMarks { get; set; }
        public DissapearDetails DissapeerDetails { get; set; }

        [NotMapped]
        [DisplayName("Dodaj zdjęcie")]
        public IFormFile PersonImage  { get; set; }
        
        [DisplayName("Dodaj zdjęcie")]
        [Column(TypeName = "nvarchar(400)")]
        public string ImageSrc { get; set; }




    }
}
