using CommonSolution.DTOs;
using CommonSolution.Interfaces;
using DataAccess.Context;
using DataAccess.Interfaces;
using DataAccess.Mappers;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class FinalClientRepository
    {
        private FinalClientMapper _FinalClientMapper;
        private ClientMapper _ClientMapper;
        private readonly DakDbContext _Context;
        public FinalClientRepository(DakDbContext context)
        {
            this._FinalClientMapper = new FinalClientMapper();
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

                    FinalClient finalClientEntity = this._FinalClientMapper.MapToEntity(dto);
                    finalClientEntity.IdClient = clientEntity.Id;
                    _Context.FinalClient.Add(finalClientEntity);
                   
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
