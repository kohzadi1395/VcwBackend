using System;

namespace Application.DTOs
{
    public class Comment
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public Guid? TableId { get; set; }
    }
}