using CommonSolution.DTOs;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.DataModel.Mappers;
using CommonSolution.Interfaces;
using DataAccess.Models;

namespace BusinessLogic.DataModel.Repository
{
    public class PackageRepository
    {
        
        private PackageMapper _PackageMapper;
        private readonly DAKContext _Context;
        public PackageRepository(DAKContext context)
        {
            
            this._PackageMapper = new PackageMapper();
            this._Context = context;
        }

        public void Add(PackageDto dto)
        {           
            Package packageEntity = this._PackageMapper.MapToEntity(dto);
            _Context.Package.Add(packageEntity);
            _Context.SaveChanges();
            dto.Id = packageEntity.Id;
        }

        public List<PackageDto> GetAll()
        {
            return this._PackageMapper.MapToDto(this._Context.Package.AsNoTracking().ToList());
        }

        public void Update(PackageDto dto)
        {
            Package trann = this._Context.Package.FirstOrDefault(x => x.Id == dto.Id);
            trann.Price = dto.Price;
            trann.Paid = dto.Paid;
            trann.TrackingNumber = dto.TrackingNumber;
            this._Context.Package.Attach(trann);
            this._Context.Entry(trann).State = EntityState.Modified;

        }

        public PackageDto GetById(int id)
        {
            return this._PackageMapper.MapToDto(this._Context.Package.FirstOrDefault(x => x.Id == id));
        }
    }
}
