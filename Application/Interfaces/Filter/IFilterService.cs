using System.Collections.Generic;
using Application.DTOs;

namespace Application.Interfaces.Filter
{
    public interface IFilterService
    {
        IEnumerable<Domain.Entities.Filter> GetAllFilters();
        void Insert(Domain.Entities.Filter filter);
        void Insert(ChallengeFilterDto challengeFilterDto);
    }
}