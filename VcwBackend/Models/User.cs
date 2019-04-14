using System;
using System.Collections.Generic;

namespace VcwBackend.Models
{
    public class User
    {
        public User()
        {
            Invites = new HashSet<Invit>();
        }

        public Guid Id { get; set; }
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Invit> Invites { get; set; }
    }
}