using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class PackageStatus
    {
        public PackageStatus()
        {
            Packages = new HashSet<Package>();
        }

        public int StatusCode { get; set; }
        public string Status { get; set; }

        public virtual ICollection<Package> Packages { get; set; }
    }
}
