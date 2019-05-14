using Application.Interfaces.Invite;
using Domain.Entities;
using Persistence.Core;

namespace Persistence.Repositories
{
    public class InviteRepository : Repository<Invite>, IInviteRepository
    {
        public InviteRepository(ApiContext context) : base(context)
        {
        }
    }
}