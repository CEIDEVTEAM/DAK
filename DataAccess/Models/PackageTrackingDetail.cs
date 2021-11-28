using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class PackageTrackingDetail
    {
        public int Id { get; set; }
        public int IdPackage { get; set; }
        public DateTime DateTime { get; set; }
        public string Ubication { get; set; }
        public int? StatusCode { get; set; }

        public virtual Package IdPackageNavigation { get; set; }
        public virtual PackageStatus StatusCodeNavigation { get; set; }
    }
}
