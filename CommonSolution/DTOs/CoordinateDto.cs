using CommonSolution.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonSolution.DTOs
{
    public class CoordinateDto : IDto
    {
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int? OrderNumber { get; set; }
        public int IdDeliveryArea { get; set; }

    }
}
