﻿using CommonSolution.DTOs;
using DataAccess.Context;
using DataAccess.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Logic
{
    public class LPackageController
    {
        private Repository _Repository;
       

        public LPackageController(DAKContext context)
        {
            
            this._Repository = new Repository();
        }

        public PackageStatusDto GetStatusByCode(int statusCode)
        {

            return this._Repository._PackageRepository.GetLogReclamoById(statusCode);
            
        }

    }
}
