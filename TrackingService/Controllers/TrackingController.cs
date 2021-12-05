using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrackingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackingController : Controller
    {
        public JsonResult Index()
        {
            string resp = "This is the Tracking Service";

            return Json(resp);
        }

        [HttpGet("ProcessRequest/{trackingNumber}", Name = "ProcessRequest")]
        public JsonResult ProcessRequest(string trackingNumber)
        {
            var random = new Random();
            var list = new List<string> {
                "Maasai Mara National Reserve",
                "Amboseli",
                "Tsavo National Park",
                "Samburu",
                "Buffalo Springs",
                "Shaba",
                "Lake Nakuru",
                "Lamu Island",
                "Lake Naivasha",
                "Nairobi",
                "David Sheldrick",
                "Malindi",
                "Mombasa",
                "Mount Kenya",
                "Hell's Gate",
                "Ol Pejeta Conservancy"
            };
            int index = random.Next(list.Count);

            string ubication = list[index];

            TrackingResponse resp = new TrackingResponse
            {
                DateTime = DateTime.Now,
                Ubication = ubication,
                StatusCode = 2

            };

            if (ubication == "Shaba" || ubication == "Lake Nakuru" || ubication == "Tsavo National Park")
                resp.StatusCode = 3;


            return Json(resp);
        }
    }
}
