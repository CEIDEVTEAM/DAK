using BusinessLogic.DataModel;
using BusinessLogic.Interfaces;
using CommonSolution.Interfaces;
using DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Logic
{
    public class LCompanyController : IController
    {
        public List<string> Add(IDto dto)
        {
            List<string> errors = new List<string>();
            using (var uow = new UnitOfWork())
            {
                if (errors.Count == 0)
                    uow.CompanyRepository.Add(dto);
            }
            return errors;
        }

        public IDto GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
