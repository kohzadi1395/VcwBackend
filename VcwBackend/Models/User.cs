using System.Collections.Generic;

namespace VcwBackend.Models
{
    public class User : BaseEntity
    {
        public User()
        {
            Invites = new HashSet<Invite>();
        }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public byte[] ProfileImage { get; set; }

        public string Company { get; set; }

        public string Title { get; set; }

        public virtual ICollection<Invite> Invites { get; set; }
    }
}