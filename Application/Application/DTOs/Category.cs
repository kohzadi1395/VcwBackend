using System;
using System.Collections.Generic;

namespace Application.DTOs
{
    public class Category
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