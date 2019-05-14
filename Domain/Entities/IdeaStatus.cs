using System;

namespace Domain.Entities
{
    public class IdeaStatus : BaseEntity
    {
        public string Description { get; set; }

        public Guid StatusId { get; set; }

        public Guid IdeaId { get; set; }

        public Guid UserId { get; set; }

        public virtual Idea Idea { get; set; }

        public virtual Status Status { get; set; }

        public virtual User User { get; set; }
    }
}