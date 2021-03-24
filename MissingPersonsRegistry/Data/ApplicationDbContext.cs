using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using MissingPersonsRegistry.Models;
using DissapearPersonsRegistry.Models;
using Microsoft.AspNetCore.Identity;

namespace MissingPersonsRegistry.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<Person> Persons { get; set; }
        public DbSet<Sex> Sex { get; set; }
        public DbSet<DissapearDetails> DissapearDetails { get; set; }
        public DbSet<DissapearPersonsRegistry.Models.User> User { get; set; }
        //public DbSet<User> Users { get; set; }
    }
}
