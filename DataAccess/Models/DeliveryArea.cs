using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class DeliveryArea
    {
        public DeliveryArea()
        {
            Cities = new HashSet<City>();
            Coordinates = new HashSet<Coordinate>();
            Packages = new HashSet<Package>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int MinPackages { get; set; }
        public string Color { get; set; }

        public virtual Expedition Expedition { get; set; }
        public virtual ICollection<City> Cities { get; set; }
        public virtual ICollection<Coordinate> Coordinates { get; set; }
        public virtual ICollection<Package> Packages { get; set; }
    }
}
