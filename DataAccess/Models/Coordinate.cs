using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Coordinate
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string Latitude { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string Longitude { get; set; }

        public int? OrderNumber { get; set; }

        public int IdDeliveryArea { get; set; }

        public virtual DeliveryArea DeliveryArea { get; set; }
    }
}
