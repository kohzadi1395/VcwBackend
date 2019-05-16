using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Application.DTOs
{
    public class ChallengeSelectionFilterDto
    {
        public Guid ChallengeId { get; set; }
        public List<Filter> Kill { get; set; }
        public List<Filter> Keep { get; set; }
        public List<Filter> Review { get; set; }
        public List<Filter> Multiply { get; set; }
    }
}