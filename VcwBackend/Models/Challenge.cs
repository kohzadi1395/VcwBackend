using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VcwBackend.Models
{
    public class Challenge: BaseEntity
    {
        public Challenge()
        {
            Invites = new HashSet<Invit>();
        }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ChallengeType { get; set; }

        public string CompanyName { get; set; }

        public DateTime? Deadline { get; set; }

        public decimal? FirstBounce { get; set; }

        public decimal? SecondBounce { get; set; }

        public decimal? ThirdBounce { get; set; }

        public int ChallengeState { get; set; }

        public virtual ICollection<Invit> Invites { get; set; }
    }
}