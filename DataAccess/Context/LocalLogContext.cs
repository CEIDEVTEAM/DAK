using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class LocalLogContext : DbContext
    {
        public LocalLogContext(DbContextOptions<LocalLogContext> options) : base(options)
        {

        }

        public virtual DbSet<Log> Log { get; set; }
        public virtual DbSet<PaymentParameters> PaymentParameters { get; set; }
        public virtual DbSet<TradingParameters> TradingParameters { get; set; }
        public virtual DbSet<User> User { get; set; }

    }
}
