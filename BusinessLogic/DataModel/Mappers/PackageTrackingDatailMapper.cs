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
    public class PackageTrackingDatailMapper
    {
        public PackageTrackingDetail MapToEntity(IDto _IDto)
        {
            if (_IDto == null)
                return null;

            PackageTrackingDatailDto dto = (PackageTrackingDatailDto)_IDto;
            return new PackageTrackingDetail()
            {
                DateTime = dto.DateTime,
                IdPackage = dto.IdPackage,
                Ubication = dto.Ubication,
                StatusCode = dto.StatusCode


            };
        }

        public PackageTrackingDatailDto MapToDto(PackageTrackingDetail entity)
        {
            if (entity == null)
                return null;

            return new PackageTrackingDatailDto
            {
                DateTime = entity.DateTime,
                IdPackage = entity.IdPackage,
                Id = entity.IdPackage,
                Ubication = entity.Ubication,
                StatusCode = entity.StatusCode
            };
        }
    }
}
