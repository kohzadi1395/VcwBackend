using System;
using System.Collections.Generic;
using Application.DTOs;
using Application.Interfaces.Challenge;
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
            _challengeRepository.Add(challenge);
        }

        public void RemoveChallenge(Guid id)
        {
            _challengeRepository.Remove(new Challenge {Id = id});
        }
    }
}