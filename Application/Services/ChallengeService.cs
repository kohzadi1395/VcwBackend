using System;
using System.Collections.Generic;
using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Services
{
    public class ChallengeService : IChallengeService
    {
        private readonly IChallengeRepository _challengeRepository;

        public ChallengeService(IChallengeRepository challengeRepository)
        {
            _challengeRepository = challengeRepository;
        }
        public IEnumerable<ChallengeUserGetDto> GetAllChallenges()
        {
            return _challengeRepository.GetAllChallenges();
        }

        public Challenge GetChallenge(Guid id)
        {
            return _challengeRepository.GetChallenge(id);
        }

        public void AddChallenge(Challenge challenge)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}