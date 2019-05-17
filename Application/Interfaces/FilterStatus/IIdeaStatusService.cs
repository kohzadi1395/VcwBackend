using System;
using System.Collections.Generic;
using Application.DTOs;

namespace Application.Interfaces.FilterStatus
{
    public interface IFilterStatusService
    {
        ChallengeSelectionFilterDto GetSelectionFilter(ChallengeSelectionFilterDto challengeSelectionFilterDto);
        ChallengeSelectionFilterDto UpdateRankFilterStatus(ChallengeSelectionFilterDto challengeSelectionFilterDto);
        ChallengeSelectionFilterDto GetSelectionFilter(Guid challengeId);
    }
}