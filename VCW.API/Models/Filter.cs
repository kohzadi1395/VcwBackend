using System;
using System.Collections.Generic;

namespace API.Models
{
    public class Filter
    {
        public Filter()
        {
            ExamIdeas = new HashSet<ExamIdea>();
        }

        public Guid Id { get; set; }

        public string Description { get; set; }

        public virtual ICollection<ExamIdea> ExamIdeas { get; set; }
    }
}