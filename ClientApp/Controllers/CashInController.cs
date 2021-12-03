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
    public class CashInController : Controller
    {
        public ActionResult CashIn()
        {
            var idPackage = HttpContext.Session.GetString("44");
            LPackageController lgc = new LPackageController();
            PackageDto dto = lgc.GetPackageById(int.Parse(idPackage));

            ViewBag.Price = dto.Price;
            ViewBag.IdPackage = dto.Id;


            return View();
        }

        public ActionResult ProcessCash(PaymentRecordDto dto)
        {
            LCashInController lcc = new LCashInController();
            lcc.PaymentProcess(dto);
            return View();
        }



    }
}
