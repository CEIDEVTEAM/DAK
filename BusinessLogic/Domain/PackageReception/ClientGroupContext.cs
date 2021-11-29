using BusinessLogic.Domain.PackageReception.PriceStrategies;
using BusinessLogic.Interfaces;
using CommonSolution.Constants;
using CommonSolution.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Domain.PackageReception
{
    public class ClientGroupContext
    {
        private IClientGroup _IClientGroup;

        public ClientGroupContext() { }

        public void SetStrategy(string clientGroup)
        {
            IClientGroup strategy;

            switch (clientGroup)
            {
                case CClientGroup.WEIGHT_AND_DISTANCE_PRICE:
                    strategy = new WeightAndDistancePrice();
                    break;
                case CClientGroup.WEIGHT_PRICE:
                    strategy = new WeightPrice();
                    break;
                case CClientGroup.FIXED_PRICE:
                    strategy = new FixedPrice();
                    break;
                default:
                    strategy = new FixedPrice();
                    break;
            }

            this._IClientGroup = strategy;
        }

        public float? CalculatePrice(PackageDto dto)
        {
            float? result = null;

            if (this._IClientGroup != null)
                result = this._IClientGroup.CalculatePrice(dto);

            return result;
        }

    }
}
