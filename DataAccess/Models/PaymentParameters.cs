using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccess.Models
{
    public partial class PaymentParameters
    {
        [Key]
        public int id { get; set; }

        [Required]
        [StringLength(40)]
        public string PaymentMethod { get; set; }

        public bool ActiveFlag { get; set; }

        [Required]
        [StringLength(1)]
        public string HaveChangeFlag { get; set; }

        public int? Discount { get; set; }

        public int? Overrun { get; set; }

        [Column(TypeName = "date")]
        public DateTime LastUpdate { get; set; }
    }

}
