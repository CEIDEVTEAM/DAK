using BusinessLogic.Interfaces;
using BusinessLogic.Logic;
using CommonSolution.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Controllers
{
    [Route("api/Package")]
    [ApiController]
    public class PackageController : Controller
    {
        [HttpPost]
        public List<string> Post([FromBody] PackageDto dto)
        {
            IController lgc = new LPackageController();
            return lgc.Add(dto);
        }
    }
}
