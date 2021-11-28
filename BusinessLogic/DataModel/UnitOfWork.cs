using BusinessLogic.DataModel.Repository;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DataModel
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        protected readonly DAKContext _context;
        protected DbContextTransaction _transaction;

        public CompanyRepository CompanyRepository { get; set; }
        public FinalClientRepository FinalClientRepository { get; set; }
        public PackageRepository PackageRepository { get; set; }
        public DeliveryAreaRepository DeliveryAreaRepository { get; set; }
        public UnitOfWork()
        {
            this._context = new DAKContext();
            
            this.CompanyRepository = new CompanyRepository(this._context);
            this.FinalClientRepository = new FinalClientRepository(this._context);
            this.PackageRepository = new PackageRepository(this._context);
            this.DeliveryAreaRepository = new DeliveryAreaRepository(this._context);

        }
        public void BeginTransaction()
        {
            _transaction = (DbContextTransaction)this._context.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
        }

        public void Commit()
        {
            if (this._transaction != null)
                this._transaction.Commit();
        }

        public void Dispose()
        {
           this._context.Dispose();
        }

        public void Rollback()
        {
            if (this._transaction != null)
                this._transaction.Rollback();
        }

        public void SaveChanges()
        {
            this._context.SaveChanges();
        }
    }
}
