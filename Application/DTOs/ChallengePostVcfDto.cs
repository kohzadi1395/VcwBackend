using System;
using System.Collections.Generic;

namespace Application.DTOs
{
    public class ChallengePostVcfDto
    {
        public Guid ChallengeId { get; set; }
        public List<VcfResultDto> VcfResultDtOs { get; set; }
    }
}