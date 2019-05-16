using Application.DTOs;

namespace Application.Interfaces.IdeaStatus
{
    public interface IIdeaStatusService
    {
        ChallengeSelectionIdeaDto GetSelectionIdea(ChallengeSelectionIdeaDto challengeSelectionIdeaDto);
    }
}