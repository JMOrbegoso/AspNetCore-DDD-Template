using DDD_Template.Domain.Base.Entities;
using DDD_Template.Domain.Base.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Immutable;
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

        public virtual IImmutableList<TEntity> GetAll()
        {
            return this.DbSet.ToImmutableList();
        }

        public virtual TEntity GetById(Guid id)
        {
            return this.DbSet.Find(id);
        }

        public virtual IImmutableList<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate)
        {
            return this.DbSet.Where(predicate).ToImmutableList();
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