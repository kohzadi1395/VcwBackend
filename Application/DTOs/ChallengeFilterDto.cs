using System.Collections.Generic;
using Domain.Entities;

namespace Application.DTOs
{
    public class ChallengeFilterDto : Challenge
    {
        public List<Filter> Filters { get; set; }
    }
}