﻿using BusinessLogic.Interfaces;
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
        

        public CompanyController()
        {
        }


        // POST api/<ValuesController>
        [HttpPost]
        public List<string> Post([FromBody] CompanyDto dto)
        {
            IController lgc = new LCompanyController();
            return lgc.Add(dto);
        }
    }
}
