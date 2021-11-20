using CommonSolution.DTOs;
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
        public PackageStatus MapToEntity(PackageStatusDto dto)
        {
            if (dto == null)
                return null;

            return new PackageStatus
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
