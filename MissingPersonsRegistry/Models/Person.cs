using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MissingPersonsRegistry.Models
{
    public class Person
    {
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        public string Name { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        public string Surname { get; set; }
        [Column(TypeName = "date")]
        public DateTime DateOfBirth { get; set; }
        public int SexId { get; set; }
        public Sex Sex { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Hair { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Eyes { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Nationality { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        public string IdentifyingMarks { get; set; }
        public DissapearDetails DissapeerDetails { get; set; }




    }
}
