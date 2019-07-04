using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class IdeaStatus : BaseEntity
    {
        public IdeaStatus()
        {
            FilterIdeaPasseds = new HashSet<FilterIdeaPassed>();
        }

        public string Description { get; set; }

        public Guid StatusId { get; set; }

        public Guid IdeaId { get; set; }

        public Guid UserId { get; set; }

        public virtual Idea Idea { get; set; }

        public virtual Status Status { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<FilterIdeaPassed> FilterIdeaPasseds { get; set; }
    }
}