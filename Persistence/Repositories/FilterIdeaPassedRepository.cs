using System;
using System.Linq;
using Application.Interfaces.Vcf;
using Domain.Entities;
using Persistence.Core;

namespace Persistence.Repositories
{
    public class FilterIdeaPassedRepository : Repository<FilterIdeaPassed>, IFilterIdeaPassedRepository
    {
        private readonly ApiContext _context;

        public FilterIdeaPassedRepository(ApiContext context) : base(context)
        {
            _context = context;
        }

        public FilterIdeaPassed GetFilterIdea(Guid ideaStatusId, Guid filterStatusId, Guid userId)
        {
            var filterIdeaPassed = _context.FilterIdeaPasseds.FirstOrDefault(x => x.IdeaStatusId == ideaStatusId
                                                                                  && x.FilterStatusId ==
                                                                                  filterStatusId
                                                                                  && x.UserId == userId);
            return filterIdeaPassed;

        }
    }
}