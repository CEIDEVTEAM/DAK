using BusinessLogic.DataModel;
using BusinessLogic.Domain.PackageReception;
using BusinessLogic.Interfaces;
using BusinessLogic.Valdations.ValidationRules;
using CommonSolution.DTOs;
using CommonSolution.Interfaces;
using DataAccess.Context;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Logic
{
    public class LPackageController
    {
        public List<string> Add(IDto Idto)
        {
            PackageDto dto = (PackageDto)Idto;

            List<string> errors = ValidatePackage(dto);

            if (errors.Count == 0)
            {
                using (var uow = new UnitOfWork())
                {
                    uow.BeginTransaction();
                    try
                    {
                        dto = this.PackageMapping(dto);
                        uow.PackageRepository.Add(dto);
                        uow.PackageTrackingDatailRespository.Add(this.TrackingDetailMapping(dto.Id));
                        uow.SaveChanges();
                        uow.Commit();
                    }
                    catch (Exception ex)
                    {
                        errors.Add("Error al comunicarse con la base de datos");
                        uow.Rollback();
                    }
                }
            }
            return errors;
        }

        public List<PackageDto> GetAll()
        {
            List<PackageDto> dto;
            using (var uow = new UnitOfWork())
            {
                dto = uow.PackageRepository.GetAll();
            }
            return dto;
        }

        public List<string> ValidatePackage(PackageDto dto)
        {
            List<string> errors = new List<string>();
            PackageValidationsRules validations = new PackageValidationsRules(dto, errors);
            return errors;
        }

        public bool ProcessPayment(IPaymentMethod paymentMethod, float amount)
        {
            PaymentMethodContext context = new PaymentMethodContext(paymentMethod);

            bool response = context.ProcessPayment(amount);

            return response;
        }

        private PackageTrackingDatailDto TrackingDetailMapping(int idPackage)
        {
            return new PackageTrackingDatailDto
            {
                IdPackage = idPackage,
                DateTime = DateTime.Now,
                StatusCode = 1,
                Ubication = "DEPOSITO" //TODO HACER CONSTANTE

            };
        }

        private PackageDto PackageMapping(PackageDto dto)
        {
            dto.IdSender = (int)this.GetClientId(dto.IdClient);
            dto.IdReciever = (int)this.GetClientId(dto.IdRecipient);
            dto.Paid = false;
            dto.Date = DateTime.Now;
            dto.StatusCode = 1;
            if (dto.Type == "LETTER")
            {
                dto.Weight = 0;
                dto.Width = 0;
                dto.Length = 0;
                dto.Height = 0;

            }

            return dto;
        }

        private int? GetClientId(string number)
        {
            int? clientId;
            using (var uow = new UnitOfWork())
            {
                clientId = uow.FinalClientRepository.GetFinalClientByDoc(number);
                if (clientId == null)
                    uow.CompanyRepository.GetCompanyIdByRut(number);

            }
            return clientId;
        }
        public bool ExistClientByNumber(string clientId)
        {
            bool response = false;
            using (var uow = new UnitOfWork())
            {
                bool existFClient = uow.FinalClientRepository.AnyFinalClientByDocument(clientId);
                bool existCompany = uow.CompanyRepository.AnyCompanyByRut(clientId);

                if (existCompany || existFClient)
                    response = true;
            }
            return response;
        }
    }


}
