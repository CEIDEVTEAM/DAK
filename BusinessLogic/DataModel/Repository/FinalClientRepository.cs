using BusinessLogic.DataModel.Mappers;
using CommonSolution.Interfaces;
using DataAccess.Context;
using DataAccess.Models;
using System;


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
    }
}
