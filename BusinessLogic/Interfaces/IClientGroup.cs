using CommonSolution.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IClientGroup
    {
        float CalculatePrice(PackageDto dto);
    }
}
