using System;

namespace Domain.Entities
{
    public class FilterStatus : BaseEntity
    {
        public Guid? StatusId { get; set; }

        public Guid? FilterId { get; set; }

        public Guid UserId { get; set; }

        public virtual Filter Filter { get; set; }

        public virtual Status Status { get; set; }

        public int Rank { get; set; }

        public virtual User User { get; set; }
    }
}