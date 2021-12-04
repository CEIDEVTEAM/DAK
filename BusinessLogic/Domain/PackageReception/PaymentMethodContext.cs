using BusinessLogic.Domain.PackageReception.PaymentMethodStrategies;
using BusinessLogic.Interfaces;
using CommonSolution.Constants;
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

        public PaymentMethodContext()
        {
        }

        public PaymentMethodContext(IPaymentMethod _paymentMethod)
        {
            this.paymentMethod = _paymentMethod;
        }

        public bool ProcessPayment(float amount)
        {
            bool processed = false;

            if (this.paymentMethod != null)
                processed = this.paymentMethod.ProcessPayment(amount);

            return processed;
        }

        internal void SetStrategy(string paymentMethod)
        {
            IPaymentMethod strategy;

            switch (paymentMethod)
            {
                case CPaymentMethod.CASH:
                    strategy = new Cash();
                    break;
                case CPaymentMethod.CREDIT:
                    strategy = new CreditCard();
                    break;
                case CPaymentMethod.DEBIT:
                    strategy = new DebitCard();
                    break;
                case CPaymentMethod.MERCADO_PAGO:
                    strategy = new MercadoPago();
                    break;
                default:
                    strategy = new Cash();
                    break;
            }

            this.paymentMethod = strategy;
        }
    }
}
