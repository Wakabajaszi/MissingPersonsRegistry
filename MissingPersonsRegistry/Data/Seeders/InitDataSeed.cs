using MissingPersonsRegistry.Data;
using MissingPersonsRegistry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DissapearPersonsRegistry.Data.Seeders
{
    public class InitDataSeed
    {
        private readonly ApplicationDbContext dbContext;

        public InitDataSeed(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Seed() 
        {
            if (!dbContext.Sex.Any()) 
            {
                dbContext.Sex.AddRange(SexSeed());
                dbContext.SaveChanges();
            }
        }

        private List<Sex> SexSeed()
        {
            List<Sex> sexes = new List<Sex>()
            {
                new Sex(){Name="Mężczyna"},
                new Sex(){Name="Kobieta"}
            };

            return sexes;

        }
    }
}
