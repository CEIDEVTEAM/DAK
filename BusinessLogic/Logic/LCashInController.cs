using BusinessLogic.Domain.PackageReception;
using BusinessLogic.Domain.PackageReception.PaymentMethodStrategies;
using BusinessLogic.Interfaces;
using CommonSolution.DTOs;
using CommonSolution.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Logic
{
    public class LCashInController
    {
        public List<string> PaymentProcess(PaymentRecordDto dto)
        {
            List<string> errors = new List<string>();
            IPaymentMethod paymentMethod = new Cash();
            PaymentMethodContext context = new PaymentMethodContext(paymentMethod);
            bool response = context.ProcessPayment((float)dto.Amount);
            if(response)

            return errors;
        }
    }
}
