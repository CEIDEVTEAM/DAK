﻿using BusinessLogic.DataModel;
using BusinessLogic.Valdations.GlobalValidationsRules;
using CommonSolution.DTOs;
using CommonSolution.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Valdations.ValidationRules
{
    public class PackageValidationsRules
    {
        private readonly PackageDto dto;
        public List<string> errors;
        public PackageValidationsRules(PackageDto _dto, List<string> _errors)
        {
            dto = _dto;
            errors = _errors;
            this.SenderValidation();
            this.RecipientValidation();
            this.DistanceValidation();
            this.HeigthValidation();
            this.WidthValidation();
            this.LengthValidation();
            this.WeightValidation();
        }

        private void WeightValidation()
        {
            float weigth = dto.Weight;
            bool isPositive = new PositiveFloatValidationRule().Validate(weigth);
            if (!isPositive)
                this.errors.Add("El Peso debe ser un valor positivo");
        }

        private void LengthValidation()
        {
            float weigth = dto.Length;
            bool isPositive = new PositiveFloatValidationRule().Validate(weigth);
            if (!isPositive)
                this.errors.Add("El Largo  debe ser un valor positivo");
        }

        private void WidthValidation()
        {
            float weigth = dto.Width;
            bool isPositive = new PositiveFloatValidationRule().Validate(weigth);
            if (!isPositive)
                this.errors.Add("El Ancho debe ser un valor positivo");
        }

        private void HeigthValidation()
        {
            float weigth = dto.Height;
            bool isPositive = new PositiveFloatValidationRule().Validate(weigth);
            if (!isPositive)
                this.errors.Add("El Alto debe ser un valor positivo");
        }

        private void DistanceValidation()
        {
            int distance = dto.Distance;
            bool isPositive = new PositiveIntValidationRule().Validate(distance);
            if (!isPositive)
                this.errors.Add("La distancia debe ser un valor positivo");
        }

        private void RecipientValidation()
        {
            string sender = this.dto.IdClient;
            using (var uow = new UnitOfWork())
            {
                bool existFClient = uow.FinalClientRepository.AnyFinalClientByDocument(sender);
                bool existCompany = uow.CompanyRepository.AnyCompanyByRut(sender);

                if (!existCompany && !existFClient)
                    this.errors.Add("Cliente inexistente");
            }
        }

        private void SenderValidation()
        {
            string sender = this.dto.IdRecipient;
            using (var uow = new UnitOfWork())
            {
                bool existFClient = uow.FinalClientRepository.AnyFinalClientByDocument(sender);
                bool existCompany = uow.CompanyRepository.AnyCompanyByRut(sender);

                if (!existCompany && !existFClient)
                    this.errors.Add("Cliente inexistente");
            }
        }


    }
}
