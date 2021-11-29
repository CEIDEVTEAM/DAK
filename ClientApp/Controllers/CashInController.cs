using BusinessLogic.Logic;
using CommonSolution.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientApp.Controllers
{
    public class CashInController : Controller
    {
        public ActionResult CashIn(PackageDto dto)
        {
            ViewBag.cashPrice = dto.Price;

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
