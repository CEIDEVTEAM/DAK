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
                IdClient = dto.IdSender,
                IdRecipient = dto.IdReciever,
                Address = dto.Address,
                Distance = dto.Distance,
                Height = dto.Height,
                Weight = dto.Weight,
                Length = dto.Length,
                Width = dto.Width,
                Price = dto.Price,
                IdCity = dto.IdCity,
                IdDeliveryArea = dto.IdDeliveryArea,
                
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
                IdSender = package.IdClient,
                IdReciever = package.IdRecipient,
                Address = package.Address,
                Distance = package.Distance,
                Height = package.Height,
                Weight = package.Weight,
                Length = package.Length,
                Width = package.Width,
                Price = package.Price,
                IdCity = (int)package.IdCity,
                IdDeliveryArea = (int)package.IdDeliveryArea,
                Id = package.Id
            };
        }

        public List<IDto> MapToDto(List<Package> packages)
        {
            List<IDto> dtos = new List<IDto>();
            foreach (Package package in packages)
            {
                PackageDto dto = this.MapToDto(package);
                dtos.Add(dto);
            }
            return dtos;
        }
    }
}
