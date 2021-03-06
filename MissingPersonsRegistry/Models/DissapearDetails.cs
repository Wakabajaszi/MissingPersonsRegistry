using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        [DisplayName("Miasto")]
        [Required(ErrorMessage = "Pole jest wymagane")]
        public string City { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Ulica")]
        [Required(ErrorMessage = "Pole jest wymagane")]
        public string Street { get; set; }

        [Column(TypeName = "nvarchar(6)")]
        [DisplayName("Kod Pocztowy")]
        [Required(ErrorMessage = "Pole jest wymagane")]
        public string PostalCode { get; set; }

        [Column(TypeName = "smalldatetime")]
        [DisplayName("Data Zaginięcia")]
        [Required(ErrorMessage = "Pole jest wymagane")]
        public DateTime DissapeerDate { get; set; }

        [Column(TypeName = "Text")]
        [DisplayName("Ostatnio widziany/a(opis)")]
        public string Description { get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; }

    }
}
