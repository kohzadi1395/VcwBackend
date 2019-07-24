using System;

namespace Domain.Entities
{
    public class FilterIdeaPassed : BaseEntity
    {
        public Guid? FilterStatusId { get; set; }

        public Guid? IdeaStatusId { get; set; }

        public Guid? UserId { get; set; }

        public bool Passed { get; set; }

        public virtual FilterStatus FilterStatus { get; set; }

        public virtual IdeaStatus IdeaStatus { get; set; }

        public virtual User User { get; set; }
    }
}