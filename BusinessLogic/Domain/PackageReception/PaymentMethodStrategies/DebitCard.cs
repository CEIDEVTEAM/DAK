﻿using BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Domain.PackageReception.PaymentMethodStrategies
{
    public class DebitCard : IPaymentMethod
    {
        public bool ProcessPayment(float amount)
        {
            bool resp = false;

            var url = $"http://localhost:39309/api/CardManager/DebitCard/{amount}";

            var request = WebRequest.Create(url);
            request.Method = "GET";

            using var webResponse = request.GetResponse();
            using var webStream = webResponse.GetResponseStream();

            using var reader = new StreamReader(webStream);
            var data = reader.ReadToEnd();

            if (!string.IsNullOrEmpty(data) && data == "/true/")
                resp = true;

            return resp;
        }
    }
}
