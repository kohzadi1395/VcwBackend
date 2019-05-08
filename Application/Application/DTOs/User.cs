using System;
using System.Collections.Generic;

namespace Application.DTOs
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
        public string Title { get; set; }
        public string Company { get; set; }
        public byte[] Pic { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Invit> Invites { get; set; }
    }
}