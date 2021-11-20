using CommonSolution.DTOs;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.DataModel.Mappers;

namespace BusinessLogic.DataModel.Repository
{
    public class PackageRepository
    {
        private PackageStatusMapper _PackageStatusMapper;
        private readonly DAKContext _Context;
        public PackageRepository(DAKContext context)
        {
            this._PackageStatusMapper = new PackageStatusMapper();
            this._Context = context;
        }

        public PackageStatusDto GetLogReclamoById(int statusCode)
        {
            PackageStatusDto dto = new PackageStatusDto();
            return this._PackageStatusMapper.MapToDto(_Context.PackageStatus.AsNoTracking().FirstOrDefault(f => f.StatusCode == statusCode));
        }
    }
}
