using CommonSolution.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonSolution.DTOs
{
    public class CityDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IdDeliveryArea { get; set; }
    }
}
