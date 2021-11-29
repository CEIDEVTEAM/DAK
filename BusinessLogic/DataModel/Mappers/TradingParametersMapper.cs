using CommonSolution.DTOs;
using CommonSolution.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DataModel.Mappers
{
    public class TradingParametersMapper
    {
        public TradingParameters MapToEntity(IDto _IDto)
        {
            if (_IDto == null)
                return null;

            TradingParametersDto dto = (TradingParametersDto)_IDto;
            return new TradingParameters()
            {
                CodeName = dto.CodeName,
                Price = dto.Price,
                LastUpdate = dto.LastUpdate
                
            };
        }

        public TradingParametersDto MapToDto(TradingParameters entity)
        {
            if (entity == null)
                return null;

            return new TradingParametersDto()
            {
                Id = entity.Id,
                CodeName = entity.CodeName,
                Price = entity.Price,
                LastUpdate = entity.LastUpdate

            };
        }
    }
}
