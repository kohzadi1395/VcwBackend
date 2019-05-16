using System;
using System.Collections.Generic;
using Application.DTOs;
using Application.Interfaces.General;

namespace Application.Interfaces.Challenge
{
    public interface IChallengeRepository : IRepository<Domain.Entities.Challenge>
    {
        IEnumerable<ChallengeUserGetDto> GetAllChallenges();
        Domain.Entities.Challenge GetChallenge(Guid id);
    }
}