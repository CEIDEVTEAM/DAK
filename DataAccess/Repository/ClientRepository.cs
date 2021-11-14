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
    public class ClientRepository
    {
        private FinalClientMapper _FinalClientMapper;
        private CompanyMapper _CompanyMapper;
        private IClientMapper _IClientMapper;
        private readonly DakDbContext _Context;
        public ClientRepository(DakDbContext context)
        {
            this._FinalClientMapper = new FinalClientMapper();
            this._CompanyMapper = new CompanyMapper();
            this._Context = context;
        }


        public void AddClient(IDto dto)
        {
            using (var trann = _Context.Database.BeginTransaction())
            {
                try
                {
                    //
                    //HAY QUE VER COMO SOLUCIONAR ACA PARA QUE SEA DINAMICO
                    //
                    Client clientEntity = this._FinalClientMapper.MapToEntity(dto);
                    _Context.Client.Add(clientEntity);

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
