using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class Client
    {
        public Client()
        {
            PackageIdClientNavigations = new HashSet<Package>();
            PackageIdRecipientNavigations = new HashSet<Package>();
        }

        public int Id { get; set; }
        public string BillingType { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

        public virtual Company Company { get; set; }
        public virtual FinalClient FinalClient { get; set; }
        public virtual ICollection<Package> PackageIdClientNavigations { get; set; }
        public virtual ICollection<Package> PackageIdRecipientNavigations { get; set; }
    }
}
