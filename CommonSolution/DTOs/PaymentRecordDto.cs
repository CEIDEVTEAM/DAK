using CommonSolution.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonSolution.DTOs
{
    public class PaymentRecordDto: IDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int PackageId { get; set; }
        public string PaymentMethod { get; set; }
        public double Amount { get; set; }
    }
}
