using System;
using System.Collections.Generic;
using System.Linq;
using Application.DTOs;
using Application.Interfaces;
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

        public void Insert(Challenge challenge)
        {
            _context.Challenges.Add(challenge);
        }

        public void Remove(Guid id)
        {
            _context.Challenges.Remove(new Challenge {Id = id});
        }

        public void InsertIdea(ChallengeIdeaDto challengeIdeaDto)
        {
            var invite = _context.Invites.FirstOrDefault(x => x.ChallengeId == challengeIdeaDto.Id
                                                              && x.UserId ==
                                                              Guid.Parse("5b7127e5-b581-4a87-bbdb-5312b9ded2cc"));
            if (invite != null)
                foreach (var idea in challengeIdeaDto.Ideas)
                    if (_context.Ideas.Any(x => x.Id == idea.Id) == false)
                        _context.Ideas.Add(idea);
                    else
                        _context.Ideas.Update(idea);
            else
                _context.Invites.Add(new Invite
                {
                    Id = Guid.NewGuid(),
                    ChallengeId = challengeIdeaDto.Id,
                    UserId = Guid.Parse("5b7127e5-b581-4a87-bbdb-5312b9ded2cc"),
                    Ideas = challengeIdeaDto.Ideas
                });


            var challenge = _context.Challenges.First(x => x.Id == challengeIdeaDto.Id);

            if (challenge.ChallengeState == 2)
                challenge.ChallengeState += 1;
        }

        public void InsertFilter(ChallengeFilterDto challengeFilterDto)
        {
            var invite = new Invite
            {
                Id = Guid.NewGuid(),
                ChallengeId = challengeFilterDto.Id,
                Filters = challengeFilterDto.Filters
            };
            _context.Invites.Add(invite);
            var challenge = _context.Challenges.First(x => x.Id == challengeFilterDto.Id);
            if (challenge.ChallengeState == 3)
                challenge.ChallengeState += 1;
        }
    }
}