using DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DataModel
{
    public class UnitOfWorkLocal : IUnitOfWork, IDisposable
    {

        protected readonly LocalLogDBContext _context;
        protected DbContextTransaction _transaction;

        public UnitOfWorkLocal()
        {
            this._context = new LocalLogDBContext();

        }

        public void BeginTransaction()
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
