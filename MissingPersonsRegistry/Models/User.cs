using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace DissapearPersonsRegistry.Models
{
    public class User 
    {
        public string Id { get; set; }
        [DisplayName("Nazwa użytkownika")]
        public string UserName { get; set; }
        public string Email { get; set; }
        [DisplayName("Typ użytkownika")]
        public string RoleName { get; set; }
    }
}
