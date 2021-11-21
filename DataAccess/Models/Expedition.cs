using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class Expedition
    {
        //public Expedition()
        //{
        //    Packages = new HashSet<Package>();
        //}

        public int Id { get; set; }
        public string Truck { get; set; }
        public DateTime Date { get; set; }
        public int IdDeliveryArea { get; set; }

        public virtual DeliveryArea IdNavigation { get; set; }
        //public virtual ICollection<Package> Packages { get; set; }
    }
}
