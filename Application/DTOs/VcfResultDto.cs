using System;

namespace Application.DTOs
{
    public class VcfResultDto
    {
        public Guid FilterId { get; set; }
        public Guid IdeaId { get; set; }
        public bool IsPassed { get; set; }
    }
}