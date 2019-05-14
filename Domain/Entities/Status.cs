using System.Collections.Generic;

namespace Domain.Entities
{
    public class Status : BaseEntity
    {
        public Status()
        {
            FilterStatus = new HashSet<FilterStatus>();
            IdeaStatus = new HashSet<IdeaStatus>();
        }

        public string Description { get; set; }

        public string Title { get; set; }

        public virtual ICollection<FilterStatus> FilterStatus { get; set; }

        public virtual ICollection<IdeaStatus> IdeaStatus { get; set; }
    }
}