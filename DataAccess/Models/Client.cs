using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Client
    {
        public int Id { get; set; }

        [Required]
        [StringLength(2)]
        public string BillingType { get; set; }

        [Required]
        [StringLength(15)]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(100)]
        public string Address { get; set; }

        [StringLength(50)]
        public string EMail { get; set; }

        //public virtual Company Company { get; set; }

        //public virtual FinalClient FinalClient { get; set; }
    }
}
