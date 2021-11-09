using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class DeliveryArea
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        public int MinPackages { get; set; }

        [StringLength(20)]
        public string Color { get; set; }

        public virtual ICollection<Coordinate> Coordinate { get; set; }

        public virtual Expedition Expedition { get; set; }
    }
}
