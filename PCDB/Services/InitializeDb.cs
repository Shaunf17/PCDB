using PCDB.Models.Components;
using PCDB.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PCDB.Services
{
    public static class InitializeDb
    {
        public static void SeedData()
        {
            using (var repo = new ComponentsRepository<Component>())
            {
                CPU cpu = new CPU()
                {
                    CoreClock = "3.9GHz",
                    CoreCount = 12,
                    Description = "New AMD Ryzen experience",
                    Name = "Ryzen 7 5800X",
                    Price = 79.99m
                };

                Storage storage = new Storage()
                {
                    Name = "Samsung EVO",
                    Description = "Lightning fast SSD",
                    Price = 129.99m,
                    Size = 2000000000.00m,
                    ReadSpeed = 3200,
                    WriteSpeed = 3200
                };

                repo.Insert(cpu);
                repo.Insert(storage);
                repo.Save();
            }
        }
    }
}