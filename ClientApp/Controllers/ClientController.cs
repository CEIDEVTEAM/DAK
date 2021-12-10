using BusinessLogic.Domain.PackageReception.PaymentMethodStrategies;
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
    public class ClientController : Controller
    {
        public ActionResult NewFinalClient()
        {
            ViewBag.colClientTypeSelect = GetSelectClientType();

            return View();
        }

        public ActionResult AddFinalClient(FinalClientDto dto)
        {
            ICrudController lgc = new LFinalClientController();

            LPackageController prueba = new LPackageController();

            List<string> colErrors = lgc.Add(dto);

            //if (colErrors.Count == 0)
            //{
            //    Session[CGlobals.USER_MESSAGE] = "Usuario registrado con éxito";
            //    ModelState.Clear();
            //}

            return RedirectToAction("NewFinalClient");
        }

        public ActionResult NewCompany()
        {
            ViewBag.colClientTypeSelect = GetSelectClientType();

            return View();
        }

        public ActionResult AddCompany(CompanyDto dto)
        {
            IControllerBase lgc = new LCompanyController();

            List<string> colErrors = lgc.Add(dto);

            //if (colErrors.Count == 0)
            //{
            //    Session[CGlobals.USER_MESSAGE] = "Usuario registrado con éxito";
            //    ModelState.Clear();
            //}

            return RedirectToAction("NewCompany");
        }



        #region AUX
        public List<SelectListItem> GetSelectClientType()
        {
            IEnumerable<ClientTypeEnum> colClientTypeEnum = Enum.GetValues(typeof(ClientTypeEnum)).Cast<ClientTypeEnum>();
            List<SelectListItem> ClientTypeList = new List<SelectListItem>();
            foreach (ClientTypeEnum item in colClientTypeEnum)
            {
                SelectListItem option = new SelectListItem();
                option.Value = item.ToString();
                option.Text = item.ToString();
                ClientTypeList.Add(option);
            }

            return ClientTypeList;
        }

        #endregion

        #region VALIDATIONS
        public JsonResult ExistClientDocNumber(string IdClient)
        {
            bool response = false;
            LFinalClientController lgc = new LFinalClientController();

            response = !lgc.ExistClientByDocNumber(IdClient);
            if (response)
                return Json(data: true);
            else
                return Json(data: false);
        }

        public JsonResult ExistClientRUT(string RUT)
        {
            bool response = false;
            LCompanyController lgc = new LCompanyController();

            response = !lgc.ExistClientByRUT(RUT);
            if (response)
                return Json(data: true);
            else
                return Json(data: false);
        }
        #endregion
    }
}
