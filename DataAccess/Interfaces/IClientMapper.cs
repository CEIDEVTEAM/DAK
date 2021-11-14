using CommonSolution.DTOs;
using CommonSolution.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IClientMapper
    {
        //ClientDto MapToDto(Client entity);
        Client MapToEntity(IDto dto);
    }
}
