using DDD_Template.Domain.Base.Entities;
using System;
using System.Collections.Immutable;
using System.Linq.Expressions;

namespace DDD_Template.Domain.Base.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : IEntity
    {
        IImmutableList<TEntity> GetAll();

        TEntity GetById(Guid id);

        IImmutableList<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);

        void Remove(TEntity entity);
    }
}