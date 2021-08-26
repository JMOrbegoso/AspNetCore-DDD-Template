using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DDD_Template.Domain.Base.Repositories
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        Task<bool> Exist(Guid id);

        Task<IEnumerable<TEntity>> Get();

        Task<TEntity> Get(Guid id);

        Task<IEnumerable<TEntity>> FindAll(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);

        void Remove(TEntity entity);
    }
}