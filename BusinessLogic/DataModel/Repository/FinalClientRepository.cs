using BusinessLogic.DataModel.Mappers;
using CommonSolution.DTOs;
using CommonSolution.Interfaces;
using DataAccess.Context;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

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

        public List<FinalClientDto> GetAll()
        {
            return (from fc in this._Context.FinalClient.AsNoTracking()
                    join cli in this._Context.Client on fc.IdClient equals cli.Id
                    select new FinalClientDto {
                        IdClient = fc.IdClient,
                        DocumentNumber = fc.DocumentNumber,
                        Name = fc.Name,
                        LastName = fc.LastName,
                        BillingType = cli.BillingType,
                        PhoneNumber = cli.PhoneNumber,
                        Address = cli.Address,
                        EMail = cli.Email
                    }).ToList();
        }

        public IDto GetById(int id)
        {
            Client entity = this._Context.Client.AsNoTracking().FirstOrDefault(x => x.Id == id);
            entity.FinalClient = this._Context.FinalClient.AsNoTracking().FirstOrDefault(x => x.IdClient == id);

            return this._FinalClientMapper.MapToDto(entity);
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
