using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    
    public partial class Log
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Task { get; set; }

        public DateTime DtLog { get; set; }

        [Required]
        [StringLength(15)]
        public string UserDocument { get; set; }

        public virtual User User { get; set; }
    }

}
