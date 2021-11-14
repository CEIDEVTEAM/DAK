using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class DakDbContext : DbContext
    {
        public DakDbContext(DbContextOptions<DakDbContext> options) : base(options)
        {

        }
      
        public DbSet<Client> Client { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Coordinate> Coordinate { get; set; }
        public DbSet<DeliveryArea> DeliveryArea { get; set; }
        public DbSet<Expedition> Expedition { get; set; }
        public DbSet<FinalClient> FinalClient { get; set; }
        public DbSet<Package> Package { get; set; }
        public DbSet<PackageStatus> PackageStatus { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coordinate>()
                .HasKey(c => new { c.Latitude, c.Longitude });
        }
       
    }
}
