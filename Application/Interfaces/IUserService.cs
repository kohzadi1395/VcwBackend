using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();
        User GetById(Guid id);
    }
}