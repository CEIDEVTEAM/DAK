using BusinessLogic.Interfaces;
using BusinessLogic.Logic;
using CommonSolution.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientApp.Controllers
{
    public class PackageController : Controller
    {
        // GET: PackageController
        public ActionResult New()
        {
            return View();
        }

        // GET: PackageController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PackageController/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetAll()
        {
            LPackageController lgc = new LPackageController();
            List<PackageDto> dto = lgc.GetAll();
            return Json(new { data = dto });
        }

        // GET: PackageController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        

    }
}
