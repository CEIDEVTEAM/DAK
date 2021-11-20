using CommonSolution.DTOs;
using CommonSolution.Interfaces;
using DataAccess.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DataModel.Mappers
{
    public class CompanyMapper
    {
        public Company MapToEntity(IDto _IDto)
        {
            if (_IDto == null)
                return null;

            CompanyDto dto = (CompanyDto)_IDto;
            return new Company
            {
                Rut = dto.Rut,
                BusinessName = dto.BusinessName
            };
        }

        public CompanyDto MapToDto(Client entity)
        {
            if (entity == null)
                return null;

            return new CompanyDto
            {
                Id = entity.Id,
                BillingType = entity.BillingType,
                PhoneNumber = entity.PhoneNumber,
                Address = entity.Address,
                EMail = entity.Email,
                Rut = entity.Company.Rut,
                BusinessName = entity.Company.BusinessName
            };
        }
    }
}
