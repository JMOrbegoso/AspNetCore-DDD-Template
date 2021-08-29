using DDD_Template.Domain.Base.Entities;
using DDD_Template.Domain.Base.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DDD_Template.Infrastructure.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IEntity
    {
        protected readonly DbContext Context;

        protected GenericRepository(DbContext context)
        {
            this.Context = context;
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return this.Context.Set<TEntity>().ToList();
        }

        public virtual TEntity GetById(Guid id)
        {
            return this.Context.Set<TEntity>().Find(id);
        }

        public virtual IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate)
        {
            return this.Context.Set<TEntity>().Where(predicate).ToList();
        }

        public virtual void Add(TEntity entity)
        {
            this.Context.Set<TEntity>().Add(entity);
        }

        public virtual void Remove(TEntity entity)
        {
            this.Context.Set<TEntity>().Remove(entity);
        }
    }
}