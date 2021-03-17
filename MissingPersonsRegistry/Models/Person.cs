using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MissingPersonsRegistry.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int SexId { get; set; }
        public Sex Sex { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public string Hair { get; set; }
        public string Eyes { get; set; }
        public string Nationality { get; set; }
        public string IdentifyingMarks { get; set; }
        public DissapeerDetails DissapeerDetails { get; set; }




    }
}
