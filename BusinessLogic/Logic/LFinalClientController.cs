using BusinessLogic.DataModel;
using BusinessLogic.Interfaces;
using CommonSolution.DTOs;
using CommonSolution.Interfaces;
using System.Collections.Generic;


namespace BusinessLogic.Logic
{
    public class LFinalClientController : ICrudController
    {
        public List<string> Add(IDto dto)
        {
            List<string> errors = new List<string>();
            using (var uow = new UnitOfWork())
            {
                if (errors.Count == 0)
                    uow.FinalClientRepository.Add(dto);
            }
            return errors;
        }

        public List<IDto> GetAll()
        {
            using (var uow = new UnitOfWork())
            {
                return uow.FinalClientRepository.GetAll();
            };
        }

        public IDto GetById(int id)
        {
            IDto dto = new FinalClientDto();
            using (var uow = new UnitOfWork())
            {
                dto = uow.FinalClientRepository.GetById(id);
            };

            return dto;
        }

        public List<string> Update(IDto dto)
        {
            throw new System.NotImplementedException();
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
