using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class PaymentParameters
    {
        public int Id { get; set; }
        public string PaymentMethod { get; set; }
        public bool ActiveFlag { get; set; }
        public string HaveChangeFlag { get; set; }
        public int? Discount { get; set; }
        public int? Overrun { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
