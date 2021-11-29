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
    public class PaymentRecordMapper
    {
        public PaymentRecord MapToEntity(IDto _IDto)
        {
            if (_IDto == null)
                return null;

            PaymentRecordDto dto = (PaymentRecordDto)_IDto;
            return new PaymentRecord
            {
                Date = dto.Date,
                PackageId = dto.PackageId,
                PaymentMethod = dto.PaymentMethod,
                Amount = dto.Amount,
            };
        }

        public PaymentRecordDto MapToDto(PaymentRecord entity)
        {
            if (entity == null)
                return null;

            return new PaymentRecordDto
            {
                Id = entity.Id,
                Date = entity.Date,
                PackageId = entity.PackageId,
                PaymentMethod = entity.PaymentMethod,
                Amount = entity.Amount,
            };
        }
    }
}
