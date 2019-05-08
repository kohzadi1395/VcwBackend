using System;

namespace Domain.Entities
{
    public class Comment : BaseEntity
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public Guid? TableId { get; set; }
    }
}