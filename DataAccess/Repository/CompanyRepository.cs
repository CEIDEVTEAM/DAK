﻿using CommonSolution.Interfaces;
using DataAccess.Context;
using DataAccess.Mappers;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class CompanyRepository
    {
        private CompanyMapper _CompanyMapper;
        private ClientMapper _ClientMapper;
        private readonly DAKContext _Context;
        public CompanyRepository(DAKContext context)
        {
            this._CompanyMapper = new CompanyMapper();
            this._ClientMapper = new ClientMapper();
            this._Context = context;
        }

        public void Add(IDto dto)
        {
            using (var trann = _Context.Database.BeginTransaction())
            {
                try
                {
                    Client clientEntity = this._ClientMapper.MapToEntity(dto);
                    _Context.Client.Add(clientEntity);
                    _Context.SaveChanges();

                    Company companyEntity = this._CompanyMapper.MapToEntity(dto);
                    companyEntity.IdClient = clientEntity.Id;
                    _Context.Company.Add(companyEntity);

                    _Context.SaveChanges();
                    trann.Commit();

                }
                catch (Exception ex)
                {
                    trann.Rollback();
                }
            }
        }
    }
}
