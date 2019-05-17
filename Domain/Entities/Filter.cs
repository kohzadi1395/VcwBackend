using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Filter : BaseEntity
    {
        public Filter()
        {
            FilterStatus = new HashSet<FilterStatus>();
        }

        public string Description { get; set; }

        public Guid InviteId { get; set; }
        public Invite Invite { get; set; }

        public string Title { get; set; }

       

        public virtual ICollection<FilterStatus> FilterStatus { get; set; }
    }
}