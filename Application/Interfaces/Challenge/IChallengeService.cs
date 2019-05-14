using System;
using System.Collections.Generic;
using Application.DTOs;

namespace Application.Interfaces.Challenge
{
    public interface IChallengeService
    {
        IEnumerable<ChallengeUserGetDto> GetAllChallenges();
        Domain.Entities.Challenge GetChallenge(Guid id);
        void AddChallenge(Domain.Entities.Challenge challenge);
        void RemoveChallenge(Guid id);
    }
}