using BusinessLogic.Interfaces;
using BusinessLogic.Logic;
using CommonSolution.DTOs;
using CommonSolution.ENUMs;
using CommonSolution.Interfaces;
using iText.Kernel.Colors;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
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
            ViewBag.colCities = GetCities();
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

        public List<SelectListItem> GetCities()
        {
            LDeliveryAreaController lcc = new LDeliveryAreaController();
            List<CityDto> colDto = lcc.GetAllCities();
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (CityDto item in colDto)
            {
                SelectListItem option = new SelectListItem();
                option.Value = item.Id.ToString();
                option.Text = item.Name;
                list.Add(option);
            }

            return list;
        }

        public ActionResult AddPackage(PackageDto dto)
        {
            LPackageController lgc = new LPackageController();

            List<string> colErrors = lgc.Add(dto);

            string id = dto.Id.ToString();
            HttpContext.Session.SetString("44", id);

            return Json(dto);
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
            List<IDto> dto = lgc.GetAll();
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
