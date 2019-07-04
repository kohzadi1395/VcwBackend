using System;
using System.Collections.Generic;
using Domain.Enums;

namespace Domain.Entities
{
    public class Challenge : BaseEntity
    {
        public Challenge()
        {
            Invites = new HashSet<Invite>();
        }

        public string Description { get; set; }

        public DateTime? Deadline { get; set; }

        public int FirstBounce { get; set; }

        public int SecondBounce { get; set; }

        public int ThirdBounce { get; set; }

        public string ChallengeType { get; set; }

        public string Title { get; set; }

        public int ChallengeState { get; set; }

        public string CompanyName { get; set; }

        public virtual ICollection<Invite> Invites { get; set; }

        public VcwLevel GetChallengeLevel()
        {
            return (VcwLevel) ChallengeState;
        }
    }
}