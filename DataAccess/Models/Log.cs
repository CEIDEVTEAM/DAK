using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class Log
    {
        public int Id { get; set; }
        public string Task { get; set; }
        public DateTime DtLog { get; set; }
        public string UserDocument { get; set; }

        public virtual User UserDocumentNavigation { get; set; }
    }
}
