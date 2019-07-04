using System.Collections.Generic;

namespace Domain.Entities
{
    public class User : BaseEntity
    {
        public User()
        {
            Invites = new HashSet<Invite>();
            FilterStatuses = new HashSet<FilterStatus>();
            IdeaStatuses = new HashSet<IdeaStatus>();
            FilterIdeaPasseds = new HashSet<FilterIdeaPassed>();
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

        public virtual ICollection<FilterStatus> FilterStatuses { get; set; }

        public virtual ICollection<IdeaStatus> IdeaStatuses { get; set; }

        public virtual ICollection<FilterIdeaPassed> FilterIdeaPasseds { get; set; }
    }
}