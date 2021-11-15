using CommonSolution.DTOs;
using CommonSolution.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mappers
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

        public FinalClientDto MapToDto(Client entity)
        {
            if (entity == null)
                return null;

            return new FinalClientDto
            {
                Id = entity.Id,
                BillingType = entity.BillingType,
                PhoneNumber = entity.PhoneNumber,
                Address = entity.Address,
                EMail = entity.Email,
                IdClient = entity.FinalClient.IdClient,
                DocumentNumber = entity.FinalClient.DocumentNumber,
                Name = entity.FinalClient.Name,
                LastName = entity.FinalClient.LastName
            };
        }

    }
}


