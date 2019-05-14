using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Application.Interfaces.General;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Core
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DbSet<TEntity> _dbSet;
        protected readonly ApiContext Context;

        public Repository(ApiContext context)
        {
            Context = context;
            _dbSet = Context.Set<TEntity>();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> criteria)
        {
            return _dbSet.Where(criteria);
        }

        public void Add(TEntity entity)
        {
            entity.CreateDate = DateTime.Now;
            entity.ModifyDate = DateTime.Now;

            _dbSet.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            entities = entities.Select(x =>
            {
                x.CreateDate = DateTime.Now;
                x.ModifyDate = DateTime.Now;
                return x;
            });
            _dbSet.AddRange(entities);
        }

        public TEntity GetById(Guid id)
        {
            return _dbSet.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public void Update(TEntity entity)
        {
            entity.ModifyDate = DateTime.Now;
            _dbSet.Update(entity);
        }

        public IEnumerable<TEntity> Find(ISpecification<TEntity> spec)
        {
            throw new NotImplementedException();
        }
    }
}