using System.Collections.Generic;
using Domain.Entities;

namespace Application.DTOs
{
    public class ChallengeIdeaDto : Challenge
    {
        public List<Idea> Ideas { get; set; }
    }
}