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
      
        public PackageRepository _PackageRepository { get; set; }
        public FinalClientRepository _FinalClientRepository { get; set; }
        public CompanyRepository _CompanyRepository { get; set; }
        public Repository()
        {
            DAKContext context = new DAKContext();
            this._PackageRepository = new PackageRepository(context);
            this._FinalClientRepository = new FinalClientRepository(context);
            this._CompanyRepository = new CompanyRepository(context);
        }

        
    }
}
