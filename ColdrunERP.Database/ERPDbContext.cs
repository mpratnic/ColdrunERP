using ColdrunERP.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace ColdrunERP.Database
{
    public class ERPDbContext : DbContext
    {
        public DbSet<Truck> Trucks { get; set; }
        public DbSet<TruckStatus> TruckStatuses { get; set; }
        public DbSet<TruckStatusRule> TruckStatusRules { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           // optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SchoolDb;Trusted_Connection=True;");
        }
    }
}