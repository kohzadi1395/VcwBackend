using System.Collections.Generic;
using Application.DTOs;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IFilterService
    {
        IEnumerable<Filter> GetAllFilters();
        void Insert(Filter filter);
        void Insert(ChallengeFilterDto challengeFilterDto);
    }
}