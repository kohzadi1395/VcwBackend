using System;
using System.Linq;
using Application.DTOs;
using Application.Interfaces.IdeaStatus;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Core;

namespace Persistence.Repositories
{
    public class IdeaStatusRepository : Repository<IdeaStatus>, IIdeaStatusRepository
    {
        private readonly ApiContext _context;

        public IdeaStatusRepository(ApiContext context) : base(context)
        {
            _context = context;
        }

        public ChallengeSelectionIdea GetSelectionIdea(ChallengeSelectionIdea challengeSelectionIdea)
        {
            var ideaStatuses = _context.IdeaStatuses
                .Include(ideaStatus => ideaStatus.Status)
                .Include(ideaStatus => ideaStatus.User)
                .Include(ideaStatus => ideaStatus.Idea)
                .ThenInclude(idea => idea.Invite)
                .Where(x => x.Idea.Invite.UserId == Guid.Parse("5b7127e5-b581-4a87-bbdb-5312b9ded2cc")
                            && x.Idea.Invite.ChallengeId == challengeSelectionIdea.ChallengeId)
                .ToList();
            var reviewIdeas = ideaStatuses.Where(x => x.StatusId == Guid.Parse("11f4e235-bbee-4527-a88a-2d239aa91ee6"))
                .Select(x => x.Idea).ToList();
            var keepIdeas = ideaStatuses.Where(x => x.StatusId == Guid.Parse("6b2ac6fa-0895-448b-8016-70b26355b211"))
                .Select(x => x.Idea).ToList();
            var killIdea = ideaStatuses.Where(x => x.StatusId == Guid.Parse("e23a5191-5f41-4c00-b855-d87b14dc9180"))
                .Select(x => x.Idea).ToList();
            var multiplyIdeas = ideaStatuses
                .Where(x => x.StatusId == Guid.Parse("410031b0-0975-4769-88fb-ef742e2f7702")).Select(x => x.Idea)
                .ToList();
            challengeSelectionIdea.Keep = keepIdeas;
            challengeSelectionIdea.Review = reviewIdeas;
            challengeSelectionIdea.Kill = killIdea;
            challengeSelectionIdea.Multiply = multiplyIdeas;

            return challengeSelectionIdea;
        }
    }
}