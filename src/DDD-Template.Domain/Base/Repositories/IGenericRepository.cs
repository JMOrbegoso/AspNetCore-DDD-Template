using DDD_Template.Domain.Base.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DDD_Template.Domain.Base.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : IEntity
    {
        IEnumerable<TEntity> GetAll();

        TEntity GetById(Guid id);

        IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);

        void Remove(TEntity entity);
    }
}