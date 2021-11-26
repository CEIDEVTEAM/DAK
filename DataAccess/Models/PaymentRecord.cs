using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class PaymentRecord
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int PackageId { get; set; }
        public string PaymentMethod { get; set; }
        public double Amount { get; set; }
    }
}
