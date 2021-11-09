using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class FinalClient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdClient { get; set; }

        [Required]
        [StringLength(15)]
        public string DocumentNumber { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [Required]
        [StringLength(20)]
        public string LastName { get; set; }
    }
}
