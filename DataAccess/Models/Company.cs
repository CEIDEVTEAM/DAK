using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class Company
    {
        public int IdClient { get; set; }
        public string Rut { get; set; }
        public string BusinessName { get; set; }

        public virtual Client IdClientNavigation { get; set; }
    }
}
