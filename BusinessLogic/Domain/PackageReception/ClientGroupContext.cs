using BusinessLogic.Domain.PackageReception.PriceStrategies;
using BusinessLogic.Interfaces;
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
                case "WEIGHT_AND_DISTANCE_PRICE":
                    strategy = new WeightAndDistancePrice();
                    break;
                case "WEIGHT_PRICE":
                    strategy = new WeightPrice();
                    break;
                case "FIXED_PRICE":
                    strategy = new FixedPrice();
                    break;
                default:
                    strategy = new FixedPrice();
                    break;
            }

            this._IClientGroup = strategy;
        }

        public float? CalculatePrice()
        {
            float? result = null;

            if (this._IClientGroup != null)
                result = this._IClientGroup.CalculatePrice();

            return result;
        }

    }
}
