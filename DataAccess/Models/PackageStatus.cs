using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class PackageStatus
    {
        public PackageStatus()
        {
            PackageTrackingDetails = new HashSet<PackageTrackingDetail>();
        }

        public int StatusCode { get; set; }
        public string Status { get; set; }

        public virtual ICollection<PackageTrackingDetail> PackageTrackingDetails { get; set; }
    }
}
