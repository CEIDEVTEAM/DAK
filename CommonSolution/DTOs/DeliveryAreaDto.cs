using CommonSolution.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonSolution.DTOs
{
    public class DeliveryAreaDto:IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MinPackages { get; set; }
        public string Color { get; set; }

        public List<CoordinateDto> ColVexels { get; set; }
    }
}
