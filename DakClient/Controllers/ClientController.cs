using BusinessLogic.Interfaces;
using BusinessLogic.Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Controllers;

namespace DakClient.Controllers
{
    public class ClientController : Controller
    {
        // GET: ClientController
        public ActionResult Index()
        {
            
            return View();
        }

        // GET: ClientController/Details/5
        public ActionResult List()
        {
            IController lgc = new LFinalClientController();
            lgc.GetById(3);
            return View(lgc);
        }
    }
}
