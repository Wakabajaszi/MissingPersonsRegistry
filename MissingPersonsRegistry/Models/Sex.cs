using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MissingPersonsRegistry.Models
{
    [Table("Sex")]
    public class Sex
    {
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        [DisplayName("Płeć")]
        public string Name { get; set; }
        public List<Person> Persons { get; set; }

    }
}
