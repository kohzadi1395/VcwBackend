using System;

namespace VcwBackend.Models
{
    public class Filter : BaseEntity
    {
        public string Description { get; set; }

        public Guid InviteId { get; set; }

        public string Title { get; set; }

        public virtual Invite Invite { get; set; }
    }
}