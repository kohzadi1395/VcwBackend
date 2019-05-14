using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Domain.Entities;

namespace Application.Interfaces.General
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        TEntity GetById(Guid id);

        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> criteria);

        void Add(TEntity entity);

        void AddRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);

        void RemoveRange(IEnumerable<TEntity> entities);

        void Update(TEntity entity);
    }
}