using BusinessLogic.DataModel.Mappers;
using CommonSolution.Interfaces;
using DataAccess.Context;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DataModel.Repository
{
    public class PackageTrackingDatailRespository
    {
        private PackageTrackingDatailMapper _PackageTrackingDatailMapper;
        private readonly DAKContext _Context;
        public PackageTrackingDatailRespository(DAKContext context)
        {
            this._PackageTrackingDatailMapper = new PackageTrackingDatailMapper();
            this._Context = context;
        }

        public void Add(IDto dto)
        {
            PackageTrackingDetail packageEntity = this._PackageTrackingDatailMapper.MapToEntity(dto);
            _Context.PackageTrackingDetail.Add(packageEntity);
        }
    }
}
