using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VcwBackend.Models
{
    public class Idea : BaseEntity
    {
        public Idea()
        {
            ExamIdeas = new HashSet<ExamIdea>();
        }

          public string Description { get; set; }

        public Guid? InvitId { get; set; }

        public virtual ICollection<ExamIdea> ExamIdeas { get; set; }

        public virtual Invit Invite { get; set; }
    }
}