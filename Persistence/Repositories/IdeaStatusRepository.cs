using System;
using System.Collections.Generic;
using System.Linq;
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

        public List<IdeaStatus> GetSelectionIdea(Guid? userId, Guid challengeId)
        {
            var ideaStatuses = _context.IdeaStatuses
                .Include(ideaStatus => ideaStatus.Status)
                .Include(ideaStatus => ideaStatus.User)
                .Include(ideaStatus => ideaStatus.Idea)
                .ThenInclude(idea => idea.Invite)
                .Where(x => x.UserId == Guid.Parse("5b7127e5-b581-4a87-bbdb-5312b9ded2cc")
                            && x.Idea.Invite.ChallengeId == challengeId)
                .ToList();
            return ideaStatuses;
        }

        public IdeaStatus GetIdeaStatus(Guid ideaId)
        {
            return _context.IdeaStatuses.FirstOrDefault(x => x.IdeaId == ideaId);

        }
    }
}