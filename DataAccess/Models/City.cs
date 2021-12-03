using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IdDeliveryArea { get; set; }

        public virtual DeliveryArea IdDeliveryAreaNavigation { get; set; }
    }
}
