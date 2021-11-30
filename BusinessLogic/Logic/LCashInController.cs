using BusinessLogic.DataModel;
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
            if (response)
            {
                LPackageController lpc = new LPackageController();
                PackageDto packageDto = lpc.GetPackageById(dto.PackageId);
                packageDto.Paid = true;

                this.Add(dto);

            }

            return errors;
        }

        public List<string> Add(PaymentRecordDto dto)
        {
            List<string> errors = new List<string>();
            using (var uow = new UnitOfWork())
            {
                if (errors.Count == 0)
                    uow.PaymentRecordRepository.Add(dto);
            }
            return errors;
        }
    }
}
