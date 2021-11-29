using CommonSolution.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonSolution.DTOs
{
    public class TradingParametersDto : IDto
    {
        public int Id { get; set; }
        public string CodeName { get; set; }
        public double? Price { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
