using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Package
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public bool Paid { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        public int IdExpedition { get; set; }

        public int StatusCode { get; set; }

        [StringLength(50)]
        public string TrackingNumber { get; set; }

        public int IdClient { get; set; }

        public int IdRecipient { get; set; }

        public virtual Client Client { get; set; }

        public virtual Client Client1 { get; set; }

        public virtual Expedition Expedition { get; set; }

        public virtual PackageStatus PackageStatus { get; set; }
    }
}
