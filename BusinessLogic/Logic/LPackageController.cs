using BusinessLogic.DataModel;
using BusinessLogic.Domain.PackageReception;
using BusinessLogic.Interfaces;
using BusinessLogic.Valdations.ValidationRules;
using CommonSolution.Constants;
using CommonSolution.DTOs;
using CommonSolution.Interfaces;
using DataAccess.Context;
using DataAccess.Models;
using MOME.GoogleMapDotNetExtension.DisntanceMatrix;
using MOME.GoogleMapDotNetExtension.DisntanceMatrix.Model;
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
                        this.CalculatePrice(dto);

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

        public List<string> UpdatePackage(PackageDto dto)
        {

            List<string> errors = ValidatePackage(dto);

            if (errors.Count == 0)
            {
                using (var uow = new UnitOfWork())
                {
                    uow.BeginTransaction();
                    try
                    {
                        uow.PackageRepository.Update(dto);

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

        private void CalculatePrice(PackageDto dto)
        {
            ClientGroupContext clientContex = new ClientGroupContext();
            string clientType = this.GetClientType(dto.IdSender);
            if (!string.IsNullOrEmpty(clientType))
            {
                clientContex.SetStrategy(clientType);
                dto.Price = clientContex.CalculatePrice(dto);

                this.UpdatePackage(dto);
            }
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
            dto.IdDeliveryArea = this.GetDeliveryAreaByCity(dto.City);
            dto.Distance = this.GetDistance("Nairobi", dto.City)/1000;
            if (dto.Type == "LETTER"||dto.Type == null)
            {
                dto.Weight = 0.100;
                dto.Width = 0.1;
                dto.Length = 0.1;
                dto.Height = 0.1;
            }

            return dto;
        }

        public PackageDto GetPackageById(int packageId)
        {
            using var uow = new UnitOfWork();
            return uow.PackageRepository.GetById(packageId);
        }

        private int GetDeliveryAreaByCity(string city)
        {
            using var uow = new UnitOfWork();
            return uow.DeliveryAreaRepository.GetDeliveryAreaByCity(city);

        }
        private int? GetClientId(string number)
        {
            int? clientId;
            using (var uow = new UnitOfWork())
            {
                clientId = uow.FinalClientRepository.GetFinalClientByDoc(number);
                if (clientId == null)
                    clientId = uow.CompanyRepository.GetCompanyIdByRut(number);

            }
            return clientId;
        }

        private string GetClientType(int id)
        {
            string clientType;
            using (var uow = new UnitOfWork())
            {
                clientType = uow.FinalClientRepository.GetClientType(id);
            }
            return clientType;
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

        public int GetDistance(string origin, string destination)
        {
            int distance = 0;
            DistanceMatrixClient disMatrix = new DistanceMatrixClient(CRoutes.APIKEY);
            DistanceMatrix response = disMatrix.RequestDistance(Unit.Metric, origin, destination);
            if (response != null)
                distance = (int)response.Disntance;

            return distance;
        }

    }


}
