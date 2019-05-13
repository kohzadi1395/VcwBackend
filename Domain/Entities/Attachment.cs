using System;

namespace Domain.Entities
{
    public class Attachment : BaseEntity
    {
        public string FileName { get; set; }

        public string Type { get; set; }

        public string Description { get; set; }

        public Guid? CategoryId { get; set; }


        public virtual Category Category { get; set; }
    }
}