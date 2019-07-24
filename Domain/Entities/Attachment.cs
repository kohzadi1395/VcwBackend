using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Attachment : BaseEntity
    {
        public string FileName { get; set; }

        public string Type { get; set; }

        public string Description { get; set; }

        public Guid? CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public Guid? ChallengeId { get; set; }

        public virtual Challenge Challenge { get; set; }
        public int ChallengeState { get; set; }

    }
}