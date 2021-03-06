using System;
using System.Collections.Generic;

namespace API.Models
{
    public class Idea
    {
        public Idea()
        {
            ExamIdeas = new HashSet<ExamIdea>();
        }

        public Guid Id { get; set; }

        public string Description { get; set; }

        public Guid? InvitId { get; set; }

        public virtual ICollection<ExamIdea> ExamIdeas { get; set; }

        public virtual Invit Invite { get; set; }
    }
}