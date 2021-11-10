using DataAccess.Context;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Persistence
{
    public class Repository
    {
        private readonly DakDbContext _Context;
        public PackageRepository _PackageRepository { get; set; }
        public Repository(DakDbContext context)
        {
            this._Context = context;
            this._PackageRepository = new PackageRepository(_Context);
        }

        
    }
}
