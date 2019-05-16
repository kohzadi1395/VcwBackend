using Application.DTOs;
using Application.Interfaces.General;

namespace Application.Interfaces.Filter
{
    public interface IFilterRepository : IRepository<Domain.Entities.Filter>
    {
        void InsertFilter(ChallengeFilterDto challengeFilterDto);
    }
}