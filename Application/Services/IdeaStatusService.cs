using Application.DTOs;
using Application.Interfaces.IdeaStatus;

namespace Application.Services
{
    public class IdeaStatusService : IIdeaStatusService
    {
        private readonly IIdeaStatusRepository _ideaStatusRepository;

        public IdeaStatusService(IIdeaStatusRepository ideaStatusRepository)
        {
            _ideaStatusRepository = ideaStatusRepository;
        }

        public ChallengeSelectionIdea GetSelectionIdea(ChallengeSelectionIdea challengeSelectionIdea)
        {
            return _ideaStatusRepository.GetSelectionIdea(challengeSelectionIdea);
        }
    }
}