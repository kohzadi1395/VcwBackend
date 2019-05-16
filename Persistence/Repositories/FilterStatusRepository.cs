using System;
using System.Collections.Generic;
using System.Linq;
using Application.Interfaces.FilterStatus;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Core;

namespace Persistence.Repositories
{
    public class FilterStatusRepository : Repository<FilterStatus>, IFilterStatusRepository
    {
        private readonly ApiContext _context;

        public FilterStatusRepository(ApiContext context) : base(context)
        {
            _context = context;
        }

        public List<FilterStatus> GetSelectionFilter(Guid? userId, Guid challengeId)
        {
            var filterStatuses = _context.FilterStatuses
                .Include(filterStatus => filterStatus.Status)
                .Include(filterStatus => filterStatus.User)
                .Include(filterStatus => filterStatus.Filter)
                .ThenInclude(filter => filter.Invite)
                .Where(x => x.UserId == Guid.Parse("5b7127e5-b581-4a87-bbdb-5312b9ded2cc")
                            && x.Filter.Invite.ChallengeId == challengeId)
                .ToList();
            return filterStatuses;
        }
    }
}