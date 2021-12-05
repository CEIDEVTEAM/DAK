using BusinessLogic.Logic;
using CommonSolution.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientApp.Controllers
{
    public class TrackingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult GetTrackingRequest(TrackingDto dto)
        {
            LTrackingController lgc = new LTrackingController();
            List<PackageTrackingDatailDto> list = lgc.GetTrackingRequest(dto);
            if (list.Count == 0)
            {
                return PartialView("_HandleErrorParcialView");
            }
            return PartialView("_TrackingInternalDetail", list);
        }
    }
}
