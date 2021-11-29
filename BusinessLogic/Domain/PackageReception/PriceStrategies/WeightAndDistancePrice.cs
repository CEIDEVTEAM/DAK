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
    public class WeightAndDistancePrice : IClientGroup
    {
        public float CalculatePrice(PackageDto dto)
        {
            float price = 0;
            string param = "WEIGHT_PRICE";
            double percent = 0.25;
            double aux = 0;

            using (var uow = new UnitOfWorkLocal())
                aux = (double)uow.tradingParametersRepository.GetPriceByCodeName(param) * percent;
            
            aux = aux * dto.Distance;
            price = (float)aux;

            return price;
        }


    }
}
