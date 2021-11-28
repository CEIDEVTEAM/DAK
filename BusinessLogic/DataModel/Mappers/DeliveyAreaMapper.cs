using CommonSolution.DTOs;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DataModel.Mappers
{
    public class DeliveyAreaMapper
    {
        #region AREA
        public DeliveryAreaDto MapToDto(DeliveryArea entity)
        {
            if (entity == null)
                return null;

            return new DeliveryAreaDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Color = entity.Color,
                MinPackages = entity.MinPackages,
                
                ColVexels = this.MapToDto(entity.Coordinates.ToList())
            };
        }

        public DeliveryArea MapToEntity(DeliveryAreaDto dto)
        {
            if (dto == null)
                return null;

            return new DeliveryArea
            {
                Id = dto.Id,
                Name = dto.Name,
                Color = dto.Color,
                MinPackages = dto.MinPackages
                
            };
        }


        public List<DeliveryAreaDto> MapToDto(List<DeliveryArea> colEntity)
        {
            List<DeliveryAreaDto> colDto = new List<DeliveryAreaDto>();

            foreach (DeliveryArea entity in colEntity)
            {
                colDto.Add(this.MapToDto(entity));
            }

            return colDto;
        }
        #endregion


        #region COORDINATES
        public CoordinateDto MapToDto(Coordinate entity)
        {
            if (entity == null)
                return null;

            return new CoordinateDto
            {

                Latitude = entity.Latitude,
                Longitude = entity.Longitude,
                IdDeliveryArea = entity.IdDeliveryArea,
                OrderNumber = (int)entity.OrderNumber,
                
            };
        }
        public List<CoordinateDto> MapToDto(List<Coordinate> ColEnt)
        {
            List<CoordinateDto> colDtoVetices = new List<CoordinateDto>();

            foreach (Coordinate item in ColEnt)
            {
                CoordinateDto Dtovert = this.MapToDto(item);
                colDtoVetices.Add(Dtovert);
            }

            return colDtoVetices;

        }

        public List<Coordinate> MapToEntity(List<CoordinateDto> Coldto)
        {
            List<Coordinate> colVetices = new List<Coordinate>();

            foreach (CoordinateDto item in Coldto)
            {
                Coordinate vert = this.MaptoEntity(item);
                colVetices.Add(vert);
            }

            return colVetices;

        }

        public Coordinate MaptoEntity(CoordinateDto dto)
        {
            if (dto == null)
                return null;

            return new Coordinate
            {

                Latitude = dto.Latitude,
                Longitude = dto.Longitude,
                IdDeliveryArea = dto.IdDeliveryArea,
                OrderNumber = dto.OrderNumber
            };
        }


        #endregion
    }
}
