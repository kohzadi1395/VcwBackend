using System;
using System.Collections.Generic;

namespace Application.Interfaces.User
{
    public interface IUserService
    {
        IEnumerable<Domain.Entities.User> GetAll();
        Domain.Entities.User GetById(Guid id);
    }
}