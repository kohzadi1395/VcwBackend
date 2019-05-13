using System;
using System.Collections.Generic;
using Application.DTOs;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IChallengeRepository : IRepository<Challenge>
    {
        IEnumerable<ChallengeUserGetDto> GetAllChallenges();
        Challenge GetChallenge(Guid id);
        void Insert(Challenge challenge);
        void InsertFilter(ChallengeFilterDto challengeFilterDto);
        void InsertIdea(ChallengeIdeaDto challengeIdeaDto);
        void Remove(Guid id);
    }
}