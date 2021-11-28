using BusinessLogic.Logic;
using ClientApp.Models;
using CommonSolution.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ClientApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public ActionResult Index1()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult PopulatePolygons()
        {
            LDeliveryAreaController lgc = new LDeliveryAreaController();
            List<DeliveryAreaDto> colDto = lgc.GetAllAreas();

            return Json(colDto);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
