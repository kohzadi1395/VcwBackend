using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Category : BaseEntity
    {
        public Category()
        {
            Attachments = new HashSet<Attachment>();
        }

        public Guid Id { get; set; }


        public string CategoryName { get; set; }

        public virtual ICollection<Attachment> Attachments { get; set; }
    }
}