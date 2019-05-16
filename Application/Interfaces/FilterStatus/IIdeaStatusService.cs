using Application.DTOs;

namespace Application.Interfaces.FilterStatus
{
    public interface IFilterStatusService
    {
        ChallengeSelectionFilterDto GetSelectionFilter(ChallengeSelectionFilterDto challengeSelectionFilterDto);
    }
}