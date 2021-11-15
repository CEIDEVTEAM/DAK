using BusinessLogic.Logic;
using CommonSolution.DTOs;
using DataAccess.Context;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageStatusController : ControllerBase
    {
        public readonly DAKContext _context;
        //public readonly LocalLogContext _LogContext;

        public PackageStatusController(DAKContext context)
        {
            this._context = context;
            //this._LogContext = logContext;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public PackageStatusDto Get()
        {
            int id = 2;
            LPackageController LController = new LPackageController(_context);
            return LController.GetStatusByCode(id);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}", Name = "GetStatus")]
        public PackageStatusDto Get(int id)
        {
            
            LPackageController LController = new LPackageController(_context);
            return LController.GetStatusByCode(id);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
