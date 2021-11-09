using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Company
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdClient { get; set; }

        [StringLength(20)]
        public string Rut { get; set; }

        [StringLength(30)]
        public string BusinessName { get; set; }
    }
}
