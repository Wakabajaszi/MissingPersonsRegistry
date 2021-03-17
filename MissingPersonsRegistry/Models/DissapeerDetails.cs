using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MissingPersonsRegistry.Models
{
    public class DissapeerDetails
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public DateTime DissapeerDate { get; set; }
        [Column(TypeName = "Text")]
        public string Desciption{ get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; }

    }
}
