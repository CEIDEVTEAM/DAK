using BusinessLogic.Interfaces;
using BusinessLogic.Logic;
using CommonSolution.DTOs;
using DataAccess.Context;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Controllers
{
    [Route("api/Company")]
    [ApiController]
    public class CompanyController : Controller
    {
        public readonly DakDbContext _context;
        public readonly LocalLogContext _LogContext;

        public CompanyController(DakDbContext context, LocalLogContext logContext)
        {
            this._context = context;
            this._LogContext = logContext;
        }


        // POST api/<ValuesController>
        [HttpPost]
        public List<string> Post([FromBody] CompanyDto dto)
        {
            IController lgc = new LCompanyController(_context);
            return lgc.Add(dto);
        }
    }
}
