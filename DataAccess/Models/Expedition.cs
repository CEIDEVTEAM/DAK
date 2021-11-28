using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class Expedition
    {
        public int Id { get; set; }
        public string Truck { get; set; }
        public DateTime Date { get; set; }

        public virtual DeliveryArea IdNavigation { get; set; }
    }
}
