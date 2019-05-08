using System;

namespace VcwBackend.Models
{
    public class ExamIdea : BaseEntity
    {

        public Guid? FilterId { get; set; }

        public Guid? IdeaId { get; set; }

        public bool? IsPassed { get; set; }

        public int? Rank { get; set; }

        public virtual Filter Filter { get; set; }

        public virtual Idea Idea { get; set; }
    }
}