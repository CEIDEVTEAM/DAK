using CommonSolution.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonSolution.DTOs
{
    public class PackageDto : IDto
    {
        public int Id { get; set; }
        public bool Paid { get; set; }
        public DateTime Date { get; set; }
        public int? IdExpedition { get; set; }
        public int StatusCode { get; set; }
        public string TrackingNumber { get; set; }
        public int IdClient { get; set; }
        public int IdRecipient { get; set; }
        public string Address { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int Distance { get; set; }

    }
}
