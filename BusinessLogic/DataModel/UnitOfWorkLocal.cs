using BusinessLogic.DataModel.Repository;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
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
        protected IDbContextTransaction _transaction;
        public TradingParametersRepository tradingParametersRepository { get; set; }

        public UnitOfWorkLocal()
        {
            this._context = new LocalLogDBContext();
            this.tradingParametersRepository = new TradingParametersRepository(_context);

        }

        public void BeginTransaction()
        {
            this._transaction = this._context.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
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
