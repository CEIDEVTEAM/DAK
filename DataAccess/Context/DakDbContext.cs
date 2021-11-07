using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class DakDbContext : DbContext
    {
        public DakDbContext(DbContextOptions<DakDbContext> options) : base(options)
        {

        }
      
        public DbSet<PackageStatus> packageStatus { get; set; }
    }
}
