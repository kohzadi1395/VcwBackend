﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using VcwBackend.Core;
using VcwBackend.DTOs;
using VcwBackend.Models;

namespace VcwBackend.Services
{
    public class ChallengeRepository
    {
        private readonly ApiContext _context;

        public ChallengeRepository()
        {
            _context = new ApiContext();
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
            _context.SaveChanges();
        }

        public void Remove(Guid id)
        {
            _context.Challenges.Remove(new Challenge {Id = id});
            _context.SaveChanges();
        }

        public void InsertIdea(ChallengeIdeaDto challengeIdeaDto)
        {
            var invite = new Invite
            {
                Id = Guid.NewGuid(),
                ChallengeId = challengeIdeaDto.Id,
                Ideas = challengeIdeaDto.Ideas
            };
            _context.Invites.Update(invite);
            var challenge = _context.Challenges.First(x => x.Id == challengeIdeaDto.Id);
            challenge.ChallengeState += 1;
            _context.SaveChanges();
        }
        public void InsertFiletr(ChallengeFilterDto challengeFilterDto)
        {
            var invite = new Invite
            {
                Id = Guid.NewGuid(),
                ChallengeId = challengeFilterDto.Id,
                Filters = challengeFilterDto.Filters
            };
            _context.Invites.Update(invite);
            var challenge = _context.Challenges.First(x => x.Id == challengeFilterDto.Id);
            challenge.ChallengeState += 1;
            _context.SaveChanges();
        }
    }
}