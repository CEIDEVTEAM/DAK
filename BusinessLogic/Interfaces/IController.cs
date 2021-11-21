using CommonSolution.DTOs;
using CommonSolution.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IController
    {
        List<string> Add(IDto dto);
        IDto GetById(int id);
    }
}
