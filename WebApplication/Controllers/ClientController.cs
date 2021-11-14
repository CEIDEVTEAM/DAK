using BusinessLogic.Interfaces;
using BusinessLogic.Logic;
using CommonSolution.DTOs;
using CommonSolution.Interfaces;
using DataAccess.Context;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Controllers
{
    [Route("api/Client")]
    [ApiController]
    public class ClientController : Controller
    {
        public readonly DakDbContext _context;
        public readonly LocalLogContext _LogContext;

        public ClientController(DakDbContext context, LocalLogContext logContext)
        {
            this._context = context;
            this._LogContext = logContext;
        }


        // POST api/<ValuesController>
        [HttpPost]
        public List<string> Post([FromBody] FinalClientDto dto)
        {
            
            IController lgc = new LClientController(_context);
            return lgc.Add(dto);
        }
    }
}
