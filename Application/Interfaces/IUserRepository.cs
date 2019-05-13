using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User GetById(Guid id);
    }
}