using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Application.DTOs
{
    public class ChallengeSelectionIdeaDto
    {
        public Guid ChallengeId { get; set; }
        public List<Idea> Kill { get; set; }
        public List<Idea> Keep { get; set; }
        public List<Idea> Review { get; set; }
        public List<Idea> Multiply { get; set; }
    }
}