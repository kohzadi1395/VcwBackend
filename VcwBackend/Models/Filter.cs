using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VcwBackend.Models
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