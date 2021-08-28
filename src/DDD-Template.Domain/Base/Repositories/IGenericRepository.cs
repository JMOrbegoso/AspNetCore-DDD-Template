using DDD_Template.Domain.Base.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DDD_Template.Domain.Base.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : IEntity
    {
        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<TEntity> GetByIdAsync(Guid id);

        Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);

        void Remove(TEntity entity);
    }
}