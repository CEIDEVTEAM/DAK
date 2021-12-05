using CommonSolution.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonSolution.DTOs
{
    public class TrackingDto : IDto
    {
        public int Id { get; set; }
        public int IdPackage { get; set; }
        public DateTime DateTime { get; set; }
        public string Ubication { get; set; }
        public int? StatusCode { get; set; }
        public string trackingNumber { get; set; }

    }
}
