using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using Test_Task_Tek_Inform.Domain.Entities;

namespace Test_Task_Tek_Inform.Domain
{
    public class EFContext : DbContext
    {
        public List<EnergyLosses> lst = new List<EnergyLosses>() {
            new EnergyLosses()
            {
                RegionID = 1,
                Date = DateTime.Now.Date,
                VolumeOfLosses = 143.3m,
                Region = new Region()
                {
                    ID = 1,
                    Name = "Москва"
                }
            },
             new EnergyLosses()
            {
                RegionID = 1,
                Date = DateTime.Now.Date,
                VolumeOfLosses = 143.3m,
                Region = new Region()
                {
                    ID = 1,
                    Name = "Москва"
                }
            },
            new EnergyLosses()
            {
                RegionID = 1,
                Date = DateTime.Now.Date,
                VolumeOfLosses = 143.3m,
                Region = new Region()
                {
                    ID = 1,
                    Name = "Москва"
                }
            }
        };

        private readonly IConfiguration _configuration;

        public EFContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<EnergyLosses> EnergyLosses => Set<EnergyLosses>();
        public DbSet<Region> Regions => Set<Region>();


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("Database"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
