using DDD_Template.Domain.Base.Entities;
using DDD_Template.Domain.Base.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DDD_Template.Infrastructure.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IEntity
    {
        protected readonly DbContext Context;

        public GenericRepository(DbContext context)
        {
            this.Context = context;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await this.Context.Set<TEntity>().ToListAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await this.Context.Set<TEntity>().FindAsync(id);
        }

        public virtual async Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await this.Context.Set<TEntity>().Where(predicate).ToListAsync();
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