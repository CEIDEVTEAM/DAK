using BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Domain.PackageReception.PaymentMethodStrategies
{
    public class MercadoPago : IPaymentMethod
    {
        public bool ProcessPayment()
        {
            throw new NotImplementedException();
        }
    }
}
