using Application.DTOs;
using Application.Interfaces.General;

namespace Application.Interfaces.Idea
{
    public interface IIdeaRepository : IRepository<Domain.Entities.Idea>
    {
        void InsertIdea(ChallengeIdeaDto challengeIdeaDto);
    }
}