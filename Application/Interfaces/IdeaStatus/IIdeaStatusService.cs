using Application.DTOs;

namespace Application.Interfaces.IdeaStatus
{
    public interface IIdeaStatusService
    {
        ChallengeSelectionIdea GetSelectionIdea(ChallengeSelectionIdea challengeSelectionIdea);
    }
}