﻿using BusinessLogic.DataModel.Repository;
using DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DataModel
{
    class UnitOfWork : IUnitOfWork, IDisposable
    {
        protected readonly DAKContext _context;
        protected DbContextTransaction _transaction;

        public CompanyRepository CompanyRepository { get; set; }
        public FinalClientRepository FinalClientRepository { get; set; }
        public PackageRepository PackageRepository { get; set; }

        public UnitOfWork()
        {
            this._context = new DAKContext();
            this.CompanyRepository = new CompanyRepository(this._context);
            this.FinalClientRepository = new FinalClientRepository(this._context);
            this.PackageRepository = new PackageRepository(this._context);

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
