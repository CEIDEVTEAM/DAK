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
    public class ClientMapper
    {
        public Client MapToEntity(IDto _IDto)
        {
            if (_IDto == null)
                return null;

            ClientDto dto = (ClientDto)_IDto;
            return new Client
            {
                BillingType = dto.BillingType,
                PhoneNumber = dto.PhoneNumber,
                Address = dto.Address,
                Email = dto.EMail,
            };
        }

    }
}
