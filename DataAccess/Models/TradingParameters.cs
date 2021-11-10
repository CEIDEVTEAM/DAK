using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class TradingParameters
    {
        [Key]
        public int id { get; set; }

        [Required]
        [StringLength(30)]
        public string CodeName { get; set; }

        public double? Price { get; set; }

        [Column(TypeName = "date")]
        public DateTime LastUpdate { get; set; }

    }
}
