using System;
using Application.DTOs;

namespace Application.Interfaces.Vcf
{
    public interface IFilterIdeaPassedService
    {
        FilterIdeaDto GetFilterIdea(Guid challengeId);
        void InsertFilterIdea(ChallengePostVcfDto postVcfDto);
    }
}