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
    public class PackageMapper
    {
        public Package MapToEntity(IDto _IDto)
        {
            if (_IDto == null)
                return null;

            PackageDto dto = (PackageDto)_IDto;
            return new Package()
            {
                Paid = dto.Paid,
                Date = dto.Date,
                IdExpedition = dto.IdExpedition,
                StatusCode = dto.StatusCode,
                TrackingNumber = dto.TrackingNumber,
                IdClient = dto.IdClient,
                IdRecipient = dto.IdRecipient,
                Address = dto.Address,
                Latitude = dto.Latitude,
                Longitude = dto.Longitude,
                Distance = dto.Distance
            };
        }

        public PackageDto MapToDto(Package package)
        {
            if (package == null)
                return null;
 
            return new PackageDto()
            {
                Paid = package.Paid,
                Date = package.Date,
                IdExpedition = package.IdExpedition,
                StatusCode = package.StatusCode,
                TrackingNumber = package.TrackingNumber,
                IdClient = package.IdClient,
                IdRecipient = package.IdRecipient,
                Address = package.Address,
                Latitude = package.Latitude,
                Longitude = package.Longitude,
                Distance = package.Distance
            };
        }

        public List<PackageDto> MapToDto(List<Package> packages)
        {
            List<PackageDto> dtos = new List<PackageDto>();
            foreach (Package package in packages)
            {
                PackageDto dto = this.MapToDto(package);
                dtos.Add(dto);
            }
            return dtos;
        }
    }
}
