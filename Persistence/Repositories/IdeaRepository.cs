using System;
using System.Linq;
using Application.DTOs;
using Application.Interfaces.Idea;
using Domain.Entities;
using Persistence.Core;

namespace Persistence.Repositories
{
    public class IdeaRepository : Repository<Idea>, IIdeaRepository
    {
        private readonly ApiContext _context;

        public IdeaRepository(ApiContext context) : base(context)
        {
            _context = context;
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
        }
    }
}