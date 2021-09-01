using DDD_Template.Domain.Base.Entities;
using System;
using System.Collections.Immutable;
using System.Linq.Expressions;

namespace DDD_Template.Domain.Base.Repositories
{
    public interface IRepository<T> where T : IAggregateRoot
    {
        IImmutableList<T> GetAll();

        T Find(Guid id);

        IImmutableList<T> Where(Expression<Func<T, bool>> predicate);
    }
}