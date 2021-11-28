using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class User
    {
        public User()
        {
            Logs = new HashSet<Log>();
        }

        public string UserDocument { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string UserType { get; set; }
        public string ActiveFlag { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Log> Logs { get; set; }
    }
}
