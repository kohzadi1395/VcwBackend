using System;
using Application.DTOs;
using Application.Interfaces.Filter;
using Domain.Entities;
using Persistence.Core;

namespace Persistence.Repositories
{
    public class FilterRepository : Repository<Filter>, IFilterRepository
    {
        private readonly ApiContext _context;

        public FilterRepository(ApiContext context) : base(context)
        {
            _context = context;
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
        }
    }
}