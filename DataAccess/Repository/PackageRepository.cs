using CommonSolution.DTOs;
using DataAccess.Mapper;
using DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class PackageRepository
    {
        private PackageStatusMapper _PackageStatusMapper;
        private readonly DakDbContext _Context;
        public PackageRepository(DakDbContext context)
        {
            this._PackageStatusMapper = new PackageStatusMapper();
            this._Context = context;
        }

        public PackageStatusDTO GetLogReclamoById(int statusCode)
        {
            PackageStatusDTO dto = new PackageStatusDTO();
            return this._PackageStatusMapper.MapToDTO(_Context.PackageStatus.AsNoTracking().FirstOrDefault(f => f.StatusCode == statusCode));
        }
    }
}
