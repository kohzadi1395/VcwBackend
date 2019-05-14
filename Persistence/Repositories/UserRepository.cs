using Application.Interfaces.User;
using Domain.Entities;
using Persistence.Core;

namespace Persistence.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApiContext context) : base(context)
        {
        }
    }
}