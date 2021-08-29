using DDD_Template.Domain.Base.Entities;
using DDD_Template.Domain.Base.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DDD_Template.Infrastructure.Repositories
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IEntity
    {
        protected DbSet<TEntity> DbSet { get; }

        protected GenericRepository(DbContext context)
        {
            this.DbSet = context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return this.DbSet.ToList();
        }

        public virtual TEntity GetById(Guid id)
        {
            return this.DbSet.Find(id);
        }

        public virtual IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate)
        {
            return this.DbSet.Where(predicate).ToList();
        }

        public virtual void Add(TEntity entity)
        {
            this.DbSet.Add(entity);
        }

        public virtual void Remove(TEntity entity)
        {
            this.DbSet.Remove(entity);
        }
    }
}