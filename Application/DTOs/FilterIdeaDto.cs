using System;
using System.Collections.Generic;

namespace Application.DTOs
{
    public class FilterIdeaDto
    {
        public Guid ChallengeId { get; set; }
        public List<FilterPassedDto> FilterPasseds { get; set; }
    }
}