using System;

namespace Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        int Commit();
    }
}