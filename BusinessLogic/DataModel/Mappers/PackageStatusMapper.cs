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
    public class PackageStatusMapper
    {
        public PackageStatus MapToEntity(IDto _IDto)
        {
            if (_IDto == null)
                return null;

            PackageStatusDto dto = (PackageStatusDto)_IDto;
            return new PackageStatus()
            {
                Status = dto.Status,
                StatusCode = dto.StatusCode
            };
        }

        public PackageStatusDto MapToDto(PackageStatus entity)
        {
            if (entity == null)
                return null;

            return new PackageStatusDto
            {
                Status = entity.Status,
                StatusCode = entity.StatusCode
            };
        }

    }
}
