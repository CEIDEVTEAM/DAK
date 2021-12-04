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
        public List<string> PaymentCashProcess(PackageDto dto)
        {
            List<string> errors = new List<string>();
            string paymentMethod = dto.PaymentMethod;
            PaymentMethodContext context = new PaymentMethodContext();
            context.SetStrategy(paymentMethod);
            bool response = context.ProcessPayment((float)dto.Price);
            if (response)
            {
                LPackageController lpc = new LPackageController();
                dto = lpc.GetPackageById(dto.Id);
                dto.Paid = true;
                dto.PaymentMethod = paymentMethod;
                lpc.UpdatePackage(dto);
                this.Add(dto);

            }

            return errors;
        }

        public List<string> PaymentDebitProcess(PackageDto dto)
        {
            List<string> errors = new List<string>();
            IPaymentMethod paymentMethod = new DebitCard();
            PaymentMethodContext context = new PaymentMethodContext(paymentMethod);
            bool response = context.ProcessPayment((float)dto.Price);
            if (response)
            {
                LPackageController lpc = new LPackageController();
                PackageDto packageDto = lpc.GetPackageById(dto.Id);
                packageDto.Paid = true;
                lpc.UpdatePackage(packageDto);
                dto.PaymentMethod = "Debit";
                this.Add(dto);

            }

            return errors;
        }
        public List<string> PaymentCreditProcess(PackageDto dto)
        {
            List<string> errors = new List<string>();
            IPaymentMethod paymentMethod = new CreditCard();
            PaymentMethodContext context = new PaymentMethodContext(paymentMethod);
            bool response = context.ProcessPayment((float)dto.Price);
            if (response)
            {
                LPackageController lpc = new LPackageController();
                PackageDto packageDto = lpc.GetPackageById(dto.Id);
                packageDto.Paid = true;
                lpc.UpdatePackage(packageDto);
                dto.PaymentMethod = "Credit";
                this.Add(dto);

            }

            return errors;
        }
        public List<string> PaymentMercadoPagoProcess(PackageDto dto)
        {
            List<string> errors = new List<string>();
            IPaymentMethod paymentMethod = new MercadoPago();
            PaymentMethodContext context = new PaymentMethodContext(paymentMethod);
            bool response = context.ProcessPayment((float)dto.Price);
            if (response)
            {
                LPackageController lpc = new LPackageController();
                PackageDto packageDto = lpc.GetPackageById(dto.Id);
                packageDto.Paid = true;
                lpc.UpdatePackage(packageDto);
                dto.PaymentMethod = "Mercado Pago";
                this.Add(dto);

            }

            return errors;
        }
        public List<string> Add(PackageDto dto)
        {
            List<string> errors = new List<string>();
            PaymentRecordDto payRecordDto = new PaymentRecordDto();
            if (dto != null)
            {
                payRecordDto.PackageId = dto.Id;
                payRecordDto.Amount = (double)dto.Price;
                payRecordDto.PaymentMethod = dto.PaymentMethod;
                payRecordDto.Date = DateTime.Now;
                using (var uow = new UnitOfWork())
                {
                    if (errors.Count == 0)
                        uow.PaymentRecordRepository.Add(payRecordDto);
                }
            }
            else {
                errors.Add("Faltan datos para procesar el pago");
            }
            
            return errors;
        }
    }
}
