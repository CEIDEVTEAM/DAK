using BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Domain.PackageReception
{
    public class PaymentMethodContext
    {
        private IPaymentMethod paymentMethod;

        public PaymentMethodContext(IPaymentMethod _paymentMethod)
        {
            this.paymentMethod = _paymentMethod;
        }

        public bool ProcessPayment()
        {
            bool processed = false;

            if (this.paymentMethod != null)
                processed = this.paymentMethod.ProcessPayment();

            return processed;
        }
    }
}
