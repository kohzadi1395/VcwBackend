using System.Collections.Generic;
using Application.DTOs;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IIdeaService
    {
        IEnumerable<Idea> GetAllIdeas();
        void Insert(Idea idea);
        void Insert(ChallengeIdeaDto challengeIdeaDto);
    }
}