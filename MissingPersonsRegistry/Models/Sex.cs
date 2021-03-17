using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MissingPersonsRegistry.Models
{
    public class Sex
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Person> Persons { get; set; }

    }
}
