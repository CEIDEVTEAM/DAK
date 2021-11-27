using BusinessLogic.DataModel;
using CommonSolution.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Logic
{
    public class LDeliveryAreaController
    {
        public void AddDeliveryArea(DeliveryAreaDto dto)
        {
            //TODO validar todo
            using (var uow = new UnitOfWork())
            {

                uow.DeliveryAreaRepository.AddArea(dto);
            }
        }

        public List<DeliveryAreaDto> GetAllAreas()
        {
            List<DeliveryAreaDto> dto = new List<DeliveryAreaDto>();
            using (var uow = new UnitOfWork())
            {
                dto = uow.DeliveryAreaRepository.GetAllAreas();
            }

            return dto;
        }
    }
}
