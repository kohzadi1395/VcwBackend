using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VcwBackend.Models
{
    public class Challenge
    {
        public Challenge()
        {
            Invites = new HashSet<Invit>();
        }

        public Guid Id { get; set; }

        public string Description { get; set; }

        public DateTime? Deadline { get; set; }

        public decimal? FirstBounce { get; set; }

        public decimal? SecondBounce { get; set; }

        public decimal? ThirdBounce { get; set; }

        public virtual ICollection<Invit> Invites { get; set; }
    }
}