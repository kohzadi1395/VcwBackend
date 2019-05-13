using System;
using System.Collections.Generic;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        TEntity GetById(Guid id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(ISpecification<TEntity> spec);

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);


        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}