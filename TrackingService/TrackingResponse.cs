using System;
namespace TrackingService
{
    public class TrackingResponse
    {
        public DateTime DateTime { get; set; }
        public string Ubication { get; set; }
        public int StatusCode { get; set; }
    }
}

