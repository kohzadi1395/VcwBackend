using Application.Interfaces.Idea;
using Domain.Entities;
using Persistence.Core;

namespace Persistence.Repositories
{
    public class IdeaRepository : Repository<Idea>, IIdeaRepository
    {
        public IdeaRepository(ApiContext context) : base(context)
        {
        }
    }
}