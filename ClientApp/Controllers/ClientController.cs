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
            IController lgc = new LFinalClientController();

            LPackageController prueba = new LPackageController();

            IPaymentMethod creditCard = new MercadoPago();
            float amount = 1564;
            bool resp = prueba.ProcessPayment(creditCard, amount);

            //List<string> colErrors = lgc.Add(dto);

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
            IController lgc = new LCompanyController();

            List<string> colErrors = lgc.Add(dto);

            //if (colErrors.Count == 0)
            //{
            //    Session[CGlobals.USER_MESSAGE] = "Usuario registrado con éxito";
            //    ModelState.Clear();
            //}

            return RedirectToAction("NewCompany  ");
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
    }
}
