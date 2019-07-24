using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

        [Column(TypeName = "decimal(18, 2)")]
        public decimal FirstBounce { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal SecondBounce { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal ThirdBounce { get; set; }

        public string ChallengeType { get; set; }

        public string Title { get; set; }

        public int ChallengeState { get; set; }

        public string CompanyName { get; set; }

        public virtual ICollection<Invite> Invites { get; set; }
        public virtual ICollection<Attachment> Attachments { get; set; }
        public VcwLevel GetChallengeLevel()
        {
            return (VcwLevel) ChallengeState;
        }
    }
}