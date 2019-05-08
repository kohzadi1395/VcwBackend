using System;

namespace API.Models
{
    public class Comment
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public Guid? TableId { get; set; }
    }
}