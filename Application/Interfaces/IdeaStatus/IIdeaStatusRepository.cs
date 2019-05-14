using Application.DTOs;
using Application.Interfaces.General;

namespace Application.Interfaces.IdeaStatus
{
    public interface IIdeaStatusRepository : IRepository<Domain.Entities.IdeaStatus>
    {
        ChallengeSelectionIdea GetSelectionIdea(ChallengeSelectionIdea challengeSelectionIdea);
    }
}