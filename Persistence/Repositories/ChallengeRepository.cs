using System;
using System.Collections.Generic;
using System.Linq;
using Application.DTOs;
using Application.Interfaces.Challenge;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Core;

namespace Persistence.Repositories
{
    public class ChallengeRepository : Repository<Challenge>, IChallengeRepository
    {
        private readonly ApiContext _context;

        public ChallengeRepository(ApiContext context) : base(context)
        {
            _context = context;
        }


        public IEnumerable<ChallengeUserGetDto> GetAllChallenges()
        {
            return _context.Challenges
                .Select(x => new ChallengeUserGetDto
                {
                    Title = x.Title,
                    Id = x.Id,
                    Description = x.Description,
                    Deadline = x.Deadline,
                    FirstBounce = x.FirstBounce,
                    SecondBounce = x.SecondBounce,
                    ThirdBounce = x.ThirdBounce,
                    ChallengeType = x.ChallengeType,
                    CompanyName = x.CompanyName,
                    ChallengeState = x.ChallengeState
                })
                .OrderBy(x => x.ChallengeState)
                .ToList();
        }

        public Challenge GetChallenge(Guid id)
        {
            return _context.Challenges
                .Include(challenge => challenge.Invites)
                .ThenInclude(invite => invite.Ideas)
                .Include(challenge => challenge.Invites)
                .ThenInclude(invite => invite.Filters)
                .Where(x => x.Id == id)
                .Select(x => new ChallengeUserGetDto
                {
                    Title = x.Title,
                    Id = x.Id,
                    Description = x.Description,
                    Deadline = x.Deadline.Value.Date,
                    FirstBounce = x.FirstBounce,
                    SecondBounce = x.SecondBounce,
                    ThirdBounce = x.ThirdBounce,
                    ChallengeState = x.ChallengeState,
                    ChallengeType = x.ChallengeType,
                    CompanyName = x.CompanyName,
                    InvitePerson = x.Invites.Select(y => y.User).ToList(),
                    Ideas = x.Invites.SelectMany(y => y.Ideas).ToList(),
                    Filters = x.Invites.SelectMany(y => y.Filters).ToList()
                })
                .FirstOrDefault();
        }


        public void Remove(Guid id)
        {
            _context.Challenges.Remove(new Challenge {Id = id});
        }
    }
}