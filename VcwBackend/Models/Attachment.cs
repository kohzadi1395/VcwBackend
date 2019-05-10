using System;

namespace VcwBackend.Models
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