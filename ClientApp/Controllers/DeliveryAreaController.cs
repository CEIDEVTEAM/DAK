using BusinessLogic.Logic;
using CommonSolution.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientApp.Controllers
{
    public class DeliveryAreaController : Controller
    {
        public IActionResult New()
        {
            return View();
        }

        public ActionResult AddDeliveryArea(DeliveryAreaDto dto)
        {
            LDeliveryAreaController lgc = new LDeliveryAreaController();
            lgc.AddDeliveryArea(dto);

            return RedirectToAction("New");
        }

        [HttpGet]
        public JsonResult PopulatePolygons()
        {
            LDeliveryAreaController lgc = new LDeliveryAreaController();
            List<DeliveryAreaDto> colDto = lgc.GetAllAreas();

            return Json(colDto);
        }

        public ActionResult List()
        {
            LDeliveryAreaController lgc = new LDeliveryAreaController();
            List<DeliveryAreaDto> colDto = lgc.GetAllAreas();

            return View(colDto);
        }

        //public ActionResult Delete(int id)
        //{
        //    LZonaController lgc = new LZonaController();
        //    DtoZona dto = lgc.GetZonaById(id);
        //    List<string> colErrors = lgc.DeleteZona(dto);

        //    if (colErrors.Count == 0)
        //    {
        //        Session[CGlobals.USER_MESSAGE] = "Zona dada de baja con éxito";
        //    }
        //    else
        //    {
        //        string errorShow = "";
        //        foreach (string item in colErrors)
        //            errorShow += "<< " + item + " >>";

        //        Session[CGlobals.USER_ALERT] = errorShow;
        //    }

        //    return RedirectToAction("List");
        //}

        //#region VALIDATIONS

        //public JsonResult ValidateNombre(string nombre)
        //{
        //    bool response = true;
        //    LZonaController lgc = new LZonaController();
        //    response = lgc.ExisteZonaByNombre(nombre) ? false : true;

        //    return Json(response, JsonRequestBehavior.AllowGet);
        //}
    }
}
