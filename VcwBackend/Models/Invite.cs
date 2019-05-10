using System;
using System.Collections.Generic;

namespace VcwBackend.Models
{
    public class Invite : BaseEntity
    {
        public Invite()
        {
            Filters = new HashSet<Filter>();
            Ideas = new HashSet<Idea>();
        }


        public bool? IsMaster { get; set; }

        public Guid? ChallengeId { get; set; }

        public Guid? UserId { get; set; }

        public virtual Challenge Challenge { get; set; }

        public virtual ICollection<Filter> Filters { get; set; }

        public virtual ICollection<Idea> Ideas { get; set; }

        public virtual User User { get; set; }
    }
}