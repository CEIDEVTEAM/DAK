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
    [Route("api/FinalClient")]
    [ApiController]
    public class FinalClientController : Controller
    {
       
        public FinalClientController()
        {
           
        }


        // POST api/<ValuesController>
        [HttpPost]
        public List<string> Post([FromBody] FinalClientDto dto)
        {
            IController lgc = new LFinalClientController();
            return lgc.Add(dto);
        }

        //[HttpGet("{id}")]
        //[HttpGet]
        //public List<FinalClientDto> Post(int id)
        //{
        //    IController lgc = new LFinalClientController();
        //    List<FinalClientDto> lst = new List<FinalClientDto>();
        //    lst.Add((FinalClientDto)lgc.GetById(id));
        //    return lst;
        //}

        [HttpGet]
        public List<FinalClientDto> GetAll()
        {
            LFinalClientController lgc = new LFinalClientController();
            return lgc.GetAll();
        }
    }
}
