using BusinessLogic.DataModel;
using BusinessLogic.Interfaces;
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
    public class LPackageController : IController
    {
        public List<string> Add(IDto Idto)
        {
            List<string> errors = new List<string>();
            PackageDto dto = (PackageDto)Idto;

            using (var uow = new UnitOfWork())
            {
                if (errors.Count == 0)
                {
                    dto.Paid = false;
                    dto.Date = DateTime.Now;
                    dto.StatusCode = 1;

                    uow.PackageRepository.Add(dto);
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

        public IDto GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool ExistClientByNumber(string number)
        {
            bool existInCompany;
            bool existInFClient;
            using (var uow = new UnitOfWork())
            {
                existInCompany = uow.FinalClientRepository.AnyFinalClientByDocument(number.ToString());
                existInFClient = uow.CompanyRepository.AnyCompanyByRut(number.ToString());
            }

            if (existInCompany || existInFClient)
                return true;
            return false;
        }

        //
        //VER SI VAMOS A VALIDAR MSIMO EN EL CONTROLLER O EN OTRA CLASE
        //QUE VALIDACIONES VAMOS A TENER ?? SOLO DE TIPOS DE DATO?
        //
        //
        public List<string> ValidateClient(IDto dto)
        {
            List<string> errors = new List<string>();

            return errors;
        }
    }
}
