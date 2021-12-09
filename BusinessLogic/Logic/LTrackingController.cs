using BusinessLogic.DataModel;
using BusinessLogic.Domain;
using CommonSolution.Constants;
using CommonSolution.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Logic
{
    public class LTrackingController
    {

        public List<PackageTrackingDatailDto> GetTrackingRequest(TrackingDto dto)
        {
            bool exist = false;
            List<PackageTrackingDatailDto> list = new List<PackageTrackingDatailDto>();
            using (var uow = new UnitOfWork())
            {
                exist = uow.PackageRepository.AnyPackageByTrackingNumber(dto.trackingNumber);
                if (exist)
                {
                    PackageDto packageDto = uow.PackageRepository.GetByTrackingNuber(dto.trackingNumber);
                    if (packageDto.StatusCode != CPackageStatusCode.DELIVERED)
                    {
                        PackageTrackingDatailDto tdto = TrackingService.HandleRequest(dto);
                        tdto.IdPackage = packageDto.Id;
                        uow.PackageTrackingDatailRespository.Add(tdto);
                        uow.SaveChanges();
                        packageDto.StatusCode = (int)tdto.StatusCode;
                        LPackageController lpc = new LPackageController();
                        lpc.Update(packageDto);


                    }

                    list = uow.PackageTrackingDatailRespository.GetTrackingByPackageId(packageDto.Id);
                }
            }

            return list;
        }

    }
}
