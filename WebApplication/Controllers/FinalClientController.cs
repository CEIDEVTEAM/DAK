using BusinessLogic.Interfaces;
using BusinessLogic.Logic;
using CommonSolution.DTOs;
using CommonSolution.Interfaces;
using DataAccess.Context;
using DataAccess.Mappers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Controllers
{
    [Route("api/FinalClient")]
    [ApiController]
    public class FinalClientController : Controller

    {
        public readonly DAKContext _context;
        //public readonly LocalLogContext _LogContext;

        public FinalClientController(DAKContext context)
        {
            this._context = context;
            //this._LogContext = logContext;
        }


        // POST api/<ValuesController>
        [HttpPost]
        public List<string> Post([FromBody] FinalClientDto dto)
        {
            IController lgc = new LFinalClientController();
            return lgc.Add(dto);
        }

        [HttpGet("{id}", Name = "GetFinalClient")]
        public IDto Get(int id)
        {

            LFinalClientController LController = new LFinalClientController();
            return LController.GetById(id);
        }
    }
}
