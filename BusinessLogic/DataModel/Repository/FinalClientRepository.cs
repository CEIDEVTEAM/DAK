using BusinessLogic.DataModel.Mappers;
using CommonSolution.DTOs;
using CommonSolution.Interfaces;
using DataAccess.Context;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DataModel.Repository
{
    public class FinalClientRepository
    {
        private FinalClientMapper _FinalClientMapper;
        private ClientMapper _ClientMapper;
        private readonly DAKContext _Context;

        public FinalClientRepository(DAKContext context)
        {
            this._FinalClientMapper = new FinalClientMapper();
            this._ClientMapper = new ClientMapper();
            this._Context = context;
        }

        public void Add(IDto dto)
        {
            Client clientEntity = this._ClientMapper.MapToEntity(dto);
            _Context.Client.Add(clientEntity);
            _Context.SaveChanges();

            FinalClient finalClientEntity = this._FinalClientMapper.MapToEntity(dto);
            finalClientEntity.IdClient = clientEntity.Id;
            _Context.FinalClient.Add(finalClientEntity);

            _Context.SaveChanges();
        }

        public List<IDto> GetAll()
        {
            return this._FinalClientMapper.MapToDto(this._Context.FinalClient.Include("Client").AsNoTracking().ToList());
        }

        public List<Client> GetAllClient()
        {
            return this._Context.Client.Include("FinalClient").AsNoTracking().ToList();
        }

        public IDto GetById(int id)
        {
            return this._FinalClientMapper.MapToDto(this._Context.FinalClient.Include("Client").AsNoTracking().FirstOrDefault(x => x.IdClient == id));
        }

        public bool AnyFinalClientByDocument(string docNumber)
        {
            return _Context.FinalClient.Any(x => x.DocumentNumber == docNumber);
        }

        public int? GetFinalClientByDoc(string docNumber)
        {
            return _Context.FinalClient.FirstOrDefault(x => x.DocumentNumber == docNumber)?.IdClient;
        }

        public string GetClientType(int id)
        {
            return _Context.Client.FirstOrDefault(x => x.Id == id).BillingType;
        }
    }
}
