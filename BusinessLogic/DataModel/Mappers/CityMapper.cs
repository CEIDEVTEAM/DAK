using CommonSolution.DTOs;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DataModel.Mappers
{
    public class CityMapper
    {
        public CityDto MapToDto(City entity){
            if(entity == null){
                return null;
            }

            return new CityDto
            {
                Name = entity.Name,
                IdDeliveryArea = entity.IdDeliveryArea,
                Id = entity.Id
            };
        }

        public List<CityDto> MapToDto(List<City> entity) {
            List<CityDto> colDto = new List<CityDto>();
            foreach (City item in entity)
            {
                colDto.Add(MapToDto(item));
            }
            return colDto;
        
        }
    }
}
