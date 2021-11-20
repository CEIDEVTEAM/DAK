using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class Coordinate
    {
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int? OrderNumber { get; set; }
        public int IdDeliveryArea { get; set; }

        public virtual DeliveryArea IdDeliveryAreaNavigation { get; set; }
    }
}
