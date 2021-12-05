using BusinessLogic.DataModel;
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
                        PackageTrackingDatailDto tdto = this.HandleRequest(dto);
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






        public PackageTrackingDatailDto HandleRequest(TrackingDto dto)
        {
            var url = $"http://localhost:40378/api/Tracking/ProcessRequest/{dto.trackingNumber}";

            var request = WebRequest.Create(url);
            request.Method = "GET";

            using var webResponse = request.GetResponse();
            using var webStream = webResponse.GetResponseStream();

            using var reader = new StreamReader(webStream);
            var data = reader.ReadToEnd();

            PackageTrackingDatailDto currDto = new PackageTrackingDatailDto();
            var resultObject = (PackageTrackingDatailDto)JsonConvert.DeserializeObject(data, currDto.GetType());

            return resultObject;
        }

    }
}
