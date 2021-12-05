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
    public class FinalClientMapper
    {
        public FinalClient MapToEntity(IDto _IDto)
        {
            if (_IDto == null)
                return null;

            FinalClientDto dto = (FinalClientDto)_IDto;
            return new FinalClient
            {
                DocumentNumber = dto.DocumentNumber,
                Name = dto.Name,
                LastName = dto.LastName
            };
        }

        public IDto MapToDto(FinalClient entity)
        {
            if (entity == null)
                return null;

            return new FinalClientDto
            {
                Id = entity.IdClientNavigation.Id,
                BillingType = entity.IdClientNavigation.BillingType,
                PhoneNumber = entity.IdClientNavigation.PhoneNumber,
                Address = entity.IdClientNavigation.Address,
                EMail = entity.IdClientNavigation.Email,
                DocumentNumber = entity.DocumentNumber,
                Name = entity.Name,
                LastName = entity.LastName
            };
        }

        public List<IDto> MapToDto(List<FinalClient> finalClients)
        {
            List<IDto> dtos = new List<IDto>();
            foreach (var item in finalClients)
            {
                dtos.Add(this.MapToDto(item));
            }
            return dtos;        
        }

    }
}


