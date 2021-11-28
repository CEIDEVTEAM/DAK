using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardManagerController : Controller
    {

        public JsonResult Index()
        {
            string resp = "This is the Payment Gateway";

            return Json(resp);
        }

        [HttpGet("CreditCard/{amount}", Name = "CreditCard")]
        public string CreditCard(float amount)
        {

            return "true";
        }

        [HttpGet("DebitCard/{amount}", Name = "DebitCard")]
        public string DebitCard(float amount)
        {

            return "true";
        }
    }
}
