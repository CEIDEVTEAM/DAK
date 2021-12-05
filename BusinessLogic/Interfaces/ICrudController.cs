using CommonSolution.DTOs;
using CommonSolution.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface ICrudController : IControllerBase
    {      
        IDto GetById(int id);
        List<IDto> GetAll();
        List<string> Update(IDto dto);

    }
}
