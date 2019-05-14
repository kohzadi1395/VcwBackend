using System.Collections.Generic;
using Application.DTOs;

namespace Application.Interfaces.Idea
{
    public interface IIdeaService
    {
        IEnumerable<Domain.Entities.Idea> GetAllIdeas();
        void Insert(Domain.Entities.Idea idea);
        void Insert(ChallengeIdeaDto challengeIdeaDto);
    }
}