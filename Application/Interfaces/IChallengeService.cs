using System;
using System.Collections.Generic;
using Application.DTOs;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IChallengeService
    {
        IEnumerable<ChallengeUserGetDto> GetAllChallenges();
        Challenge GetChallenge(Guid id);
        void AddChallenge(Challenge challenge);
        void Remove(Guid id);
    }
}