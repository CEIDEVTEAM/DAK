using BusinessLogic.Interfaces;
using BusinessLogic.Logic;
using CommonSolution.DTOs;
using CommonSolution.ENUMs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            ViewBag.colTypeSelect = GetSelectType();
            return View();
        }
        public List<SelectListItem> GetSelectType()
        {
            IEnumerable<PackageTypeEnum> colPackageTypeEnum = Enum.GetValues(typeof(PackageTypeEnum)).Cast<PackageTypeEnum>();
            List<SelectListItem> TypeList = new List<SelectListItem>();
            foreach (PackageTypeEnum item in colPackageTypeEnum)
            {
                SelectListItem option = new SelectListItem();
                option.Value = item.ToString();
                option.Text = item.ToString();
                TypeList.Add(option);
            }

            return TypeList;
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


        public JsonResult ValidateRemitent(int IdClient)
        {
            bool response = false;
            LPackageController lgc = new LPackageController();

            response = lgc.ExistClientByNumber(IdClient);
            if (response)
                return Json(data: true);
            else
                return Json(data: false);
        }

        public JsonResult ValidateRecipient(int IdClient)
        {
            bool response = false;
            LPackageController lgc = new LPackageController();

            response = lgc.ExistClientByNumber(IdClient);
            if (response)
                return Json(data: true);
            else
                return Json(data: false);
        }
    }
}
