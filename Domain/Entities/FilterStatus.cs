using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class FilterStatus : BaseEntity
    {
        public FilterStatus()
        {
            FilterIdeaPasseds = new HashSet<FilterIdeaPassed>();
        }

        public Guid? StatusId { get; set; }

        public Guid? FilterId { get; set; }

        public Guid UserId { get; set; }

        public virtual Filter Filter { get; set; }

        public virtual Status Status { get; set; }

        public int Rank { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<FilterIdeaPassed> FilterIdeaPasseds { get; set; }
        public string Description { get; set; }
    }
}