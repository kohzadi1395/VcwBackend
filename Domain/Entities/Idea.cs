using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Idea : BaseEntity
    {
        public Idea()
        {
            IdeaStatus = new HashSet<IdeaStatus>();
        }

        public string Description { get; set; }

        public Guid? InviteId { get; set; }
        public Invite Invite { get; set; }

        public string Title { get; set; }

        public virtual ICollection<IdeaStatus> IdeaStatus { get; set; }
    }
}