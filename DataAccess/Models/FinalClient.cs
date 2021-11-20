using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class FinalClient
    {
        public int IdClient { get; set; }
        public string DocumentNumber { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        public virtual Client IdClientNavigation { get; set; }
    }
}
