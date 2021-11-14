using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonSolution.DTOs
{
    public class CompanyDto : ClientDto
    {
        public int IdClient { get; set; }
        public string Rut { get; set; }
        public string BusinessName { get; set; }
    }
}
