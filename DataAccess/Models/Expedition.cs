using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Expedition
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Truck { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        public int IdDeliveryArea { get; set; }

        public virtual DeliveryArea DeliveryArea { get; set; }

        public virtual ICollection<Package> Package { get; set; }
    }
}
