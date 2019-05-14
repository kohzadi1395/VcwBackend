using Application.Interfaces.Filter;
using Domain.Entities;
using Persistence.Core;

namespace Persistence.Repositories
{
    public class FilterRepository : Repository<Filter>, IFilterRepository
    {
        public FilterRepository(ApiContext context) : base(context)
        {
        }
    }
}