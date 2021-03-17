using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MissingPersonsRegistry.Models
{
    [Table("DissapearDetails")]
    public class DissapearDetails
    {
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string City { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Street { get; set; }
        [Column(TypeName = "nvarchar(6)")]
        public string PostalCode { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime DissapeerDate { get; set; }
        [Column(TypeName = "Text")]
        public string Desciption{ get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; }

    }
}
