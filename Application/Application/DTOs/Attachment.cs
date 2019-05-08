using System;

namespace Application.DTOs
{
    public class Attachment
    {
        public Guid Id { get; set; }

        public string FileName { get; set; }

        public string Type { get; set; }

        public string Description { get; set; }

        public Guid? CategoryId { get; set; }

        public Guid? TableId { get; set; }

        public virtual Category Category { get; set; }
    }
}