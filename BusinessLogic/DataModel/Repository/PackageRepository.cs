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
        private PackageStatusMapper _PackageStatusMapper;
        private PackageMapper _PackageMapper;
        private readonly DAKContext _Context;
        public PackageRepository(DAKContext context)
        {
            this._PackageStatusMapper = new PackageStatusMapper();
            this._PackageMapper = new PackageMapper();
            this._Context = context;
        }

        public void Add(IDto dto)
        {
            Package packageEntity = this._PackageMapper.MapToEntity(dto);
            _Context.Package.Add(packageEntity);
            

        }

        public List<PackageDto> GetAll()
        {
            return this._PackageMapper.MapToDto(this._Context.Package.AsNoTracking().ToList());
        }
    }
}
