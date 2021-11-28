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
    public class DeliveryAreaRepository
    {
        private DeliveyAreaMapper _DeliveryAreaMapper;
        private readonly DAKContext _Context;
        public DeliveryAreaRepository(DAKContext context)
        {

            this._DeliveryAreaMapper = new DeliveyAreaMapper();
            this._Context = context;
        }


        public void AddArea(DeliveryAreaDto dto)
        {
            DeliveryArea newArea = this._DeliveryAreaMapper.MapToEntity(dto);

            _Context.DeliveryArea.Add(newArea);
            _Context.SaveChanges();

            foreach (CoordinateDto item in dto.ColVexels)
            {
                Coordinate vexel = this._DeliveryAreaMapper.MaptoEntity(item);
                vexel.IdDeliveryArea = newArea.Id;
                _Context.Coordinate.Add(vexel);
            }

            _Context.SaveChanges();

            //TODO: HACER TRANSACCION
        }

        

        public List<DeliveryAreaDto> GetAllAreas()
        {
            return this._DeliveryAreaMapper.MapToDto(_Context.DeliveryArea.Include("Coordinates").AsNoTracking().ToList());
        }

        
    }
}
