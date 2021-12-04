using CommonSolution.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Domain.PackageReception
{
    public class TrackingNumberGenerator
    {
        private PackageDto _PackageDto;

        public TrackingNumberGenerator(PackageDto packageDto)
        {
            this._PackageDto = packageDto;
        }

        public string GenerateTrackingNumber()
        {
            string zone = this._PackageDto.IdDeliveryArea.ToString();
            string city = this._PackageDto.IdCity.ToString();
            string packageId = this._PackageDto.Id.ToString();
            string type = "PAK";

            if (this._PackageDto.Type == "LETTER")
                type = "LET";

            string trackNum = $"DAK{type}-{packageId}Z{zone}C{city}";

            return trackNum;
        }
    }
}
