using CommonSolution.DTOs;
using CommonSolution.ENUMs;
using CommonSolution.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DataModel.Mappers
{
    public class ClientMapper
    {
        public Client MapToEntity(IDto _IDto)
        {
            if (_IDto == null)
                return null;

            ClientDto dto = (ClientDto)_IDto;
            return new Client
            {
                BillingType = this.SetBillignType(dto.BillingType),
                PhoneNumber = dto.PhoneNumber,
                Address = dto.Address,
                Email = dto.EMail,
            };
        }


        public string SetBillignType(string billingTypeDto)
        {
            string resp = "";
            Enum.TryParse(billingTypeDto, out ClientTypeEnum billingTypeEnum);

            switch (billingTypeEnum)
            {
                case ClientTypeEnum.WEIGHT_AND_DISTANCE_PRICE:
                    resp = "WD";
                    break;
                case ClientTypeEnum.FIXED_PRICE:
                    resp = "FP";
                    break;
                case ClientTypeEnum.WEIGHT_PRICE:
                    resp = "WE";
                    break;
                default:
                    break;
            }
            return resp;
        }

    }
}
