using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace VcwBackend.Models
{
    public class Challenge : BaseEntity
    {
        public Challenge()
        {
            Invites = new HashSet<Invite>();
        }


        public string Description { get; set; }

        [Column(TypeName = "datetime2")] public DateTime? Deadline { get; set; }

        public decimal? FirstBounce { get; set; }

        public decimal? SecondBounce { get; set; }

        public decimal? ThirdBounce { get; set; }

        public string ChallengeType { get; set; }

        public string Title { get; set; }

        public int ChallengeState { get; set; }

        public string CompanyName { get; set; }

        public virtual ICollection<Invite> Invites { get; set; }
    }
}