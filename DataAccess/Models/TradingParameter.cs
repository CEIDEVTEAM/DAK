using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class TradingParameter
    {
        public int Id { get; set; }
        public string CodeName { get; set; }
        public double? Price { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
