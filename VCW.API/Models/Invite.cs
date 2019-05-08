using System;
using System.Collections.Generic;

namespace API.Models
{
    public class Invit
    {
        public Invit()
        {
            Ideas = new HashSet<Idea>();
        }

        public Guid Id { get; set; }

        public bool? IsMaster { get; set; }

        public Guid? ChallengeId { get; set; }

        public Guid? UserId { get; set; }

        public virtual Challenge Challenge { get; set; }

        public virtual ICollection<Idea> Ideas { get; set; }

        public virtual User User { get; set; }
    }
}