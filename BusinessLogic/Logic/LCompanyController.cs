using BusinessLogic.Interfaces;
using CommonSolution.Interfaces;
using DataAccess.Context;
using DataAccess.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Logic
{
    public class LCompanyController : IController
    {
        private Repository _Repository;

        public LCompanyController(DakDbContext context)
        {

            this._Repository = new Repository(context);
        }

        public List<string> Add(IDto dto)
        {
            List<string> errors = new List<string>();

            if (errors.Count == 0)
                this._Repository._CompanyRepository.Add(dto);

            return errors;
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
