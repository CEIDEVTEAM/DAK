using BusinessLogic.DataModel;
using BusinessLogic.Interfaces;
using CommonSolution.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Domain.PackageReception.PriceStrategies
{
    public class WeightPrice : IClientGroup
    {
        
        public float CalculatePrice(PackageDto dto)
        {
            float price = 0;
            string param = "WEIGHT_PRICE";
            using (var uow = new UnitOfWorkLocal())
            {
                price = (float)uow.tradingParametersRepository.GetPriceByCodeName(param) * (float)dto.Weight;
            }

            return price;
        }
    }
}
