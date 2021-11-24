using BusinessLogic.DataModel;
using BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Domain.PackageReception.PriceStrategies
{
    public class FixedPrice : IClientGroup
    {
        public float CalculatePrice()
        {
            using (var uow = new UnitOfWork())
            {

                    uow.PackageRepository.Add(dto);
                
            }
        }
    }
}
