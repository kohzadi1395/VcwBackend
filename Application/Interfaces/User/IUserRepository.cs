using System;
using System.Collections.Generic;

namespace Application.Interfaces.User
{
    public interface IUserRepository
    {
        IEnumerable<Domain.Entities.User> GetAll();
        Domain.Entities.User GetById(Guid id);
    }
}