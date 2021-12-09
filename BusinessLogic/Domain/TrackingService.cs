using CommonSolution.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Domain
{
    public static class TrackingService
    {
        public static PackageTrackingDatailDto HandleRequest(TrackingDto dto)
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
