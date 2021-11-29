using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class Package
    {
        public Package()
        {
            PackageTrackingDetails = new HashSet<PackageTrackingDetail>();
        }

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
        public double? Height { get; set; }
        public double? Width { get; set; }
        public double? Weight { get; set; }
        public double? Length { get; set; }
        public int? IdDeliveryArea { get; set; }
        public double? Price { get; set; }

        public virtual Client IdClientNavigation { get; set; }
        public virtual DeliveryArea IdDeliveryAreaNavigation { get; set; }
        public virtual Client IdRecipientNavigation { get; set; }
        public virtual ICollection<PackageTrackingDetail> PackageTrackingDetails { get; set; }
    }
}
