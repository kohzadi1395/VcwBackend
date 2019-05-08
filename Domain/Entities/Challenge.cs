using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Challenge : BaseEntity
    {
        public Challenge()
        {
            Invites = new HashSet<Invit>();
        }

        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime? Deadline { get; set; }

        public decimal? FirstBounce { get; set; }

        public decimal? SecondBounce { get; set; }

        public decimal? ThirdBounce { get; set; }

        public string CompanyName { get; set; }


        public int ChallengeStateCode { get; set; }

        public bool ChallengeType { get; set; }

        public virtual ICollection<Invit> Invites { get; set; }
    }

    //    enum ChallengeState
    //    {
    //        DiscoverValue,
    //        CreateValue,
    //        ValidateValue,
    //        CaptureValue,
    //        ConsolidateValue
    //    }
    internal enum ChallengeState
    {
        DiscoverValue,
        CreateValue,
        ValidateValue,
        CaptureValue,
        ConsolidateValue
    }
}