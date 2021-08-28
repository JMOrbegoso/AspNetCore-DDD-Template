﻿using DDD_Template.Domain.Base.Entities;
using DDD_Template.Domain.Base.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DDD_Template.Infrastructure.Repositories
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        protected readonly DbContext Context;

        public GenericRepository(DbContext context)
        {
            this.Context = context;
        }

        public async Task<bool> Exist(Guid id)
        {
            return await this.Context.Set<TEntity>().FindAsync(id) != null;
        }

        public async Task<IEnumerable<TEntity>> Get()
        {
            return await this.Context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> Get(Guid id)
        {
            return await this.Context.Set<TEntity>().FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> FindAll(Expression<Func<TEntity, bool>> predicate)
        {
            return await this.Context.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public void Add(TEntity entity)
        {
            this.Context.Set<TEntity>().Add(entity);
        }

        public void Remove(TEntity entity)
        {
            this.Context.Set<TEntity>().Remove(entity);
        }
    }
}