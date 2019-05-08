using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(ISpecification<TEntity> spec);

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);


        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}