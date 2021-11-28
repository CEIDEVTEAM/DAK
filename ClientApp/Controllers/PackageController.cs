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

        public ActionResult AddPackage(PackageDto dto)
        {
            LPackageController lgc = new LPackageController();

            List<string> colErrors = lgc.Add(dto);

            //if (colErrors.Count == 0)
            //{
            //    Session[CGlobals.USER_MESSAGE] = "Usuario registrado con éxito";
            //    ModelState.Clear();
            //}

            return RedirectToAction("New");
        }
        [HttpGet]
        public JsonResult PopulatePolygons()
        {
            LDeliveryAreaController lgc = new LDeliveryAreaController();
            List<DeliveryAreaDto> colDto = lgc.GetAllAreas();

            return Json(colDto);
        }

        [HttpGet]
        public JsonResult GetAll()
        {
            LPackageController lgc = new LPackageController();
            List<PackageDto> dto = lgc.GetAll();
            return Json(new { data = dto });
        }


        public JsonResult ValidateRemitent(string IdClient)
        {
            bool response = false;
            LPackageController lgc = new LPackageController();

            response = lgc.ExistClientByNumber(IdClient);
            if (response)
                return Json(data: true);
            else
                return Json(data: false);
        }

        public JsonResult ValidateRecipient(string IdRecipient)
        {
            bool response = false;
            LPackageController lgc = new LPackageController();

            response = lgc.ExistClientByNumber(IdRecipient);
            if (response)
                return Json(data: true);
            else
                return Json(data: false);
        }
    }
}
