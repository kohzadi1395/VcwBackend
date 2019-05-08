using System;
using System.Collections.Generic;
using System.Linq;
using API.Core;
using API.Models;

namespace API.Services
{
    public class ChallengeRepository
    {
        private readonly ApiContext _context;

        public ChallengeRepository()
        {
            _context = new ApiContext();
        }

        public IEnumerable<Challenge> GetAllChallenges()
        {
            var challenges = _context.Challenges.ToList();
            return challenges;
        }

        public Challenge GetChallenge(Guid id)
        {
            var challenge = _context.Challenges
                .FirstOrDefault(x => x.Id == id);
            return challenge;
        }

        public void Insert(Challenge challenge)
        {
            _context.Challenges.Add(challenge);
            _context.SaveChanges();
        }
    }
}