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
    public class MercadoPagoController : Controller
    {

        [HttpGet("{amount}")]
        public string Mercado(float amount)
        {

            return "true";
        }

    }
}
