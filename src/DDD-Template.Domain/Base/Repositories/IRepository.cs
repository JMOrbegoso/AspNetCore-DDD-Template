﻿using DDD_Template.Domain.Base.Entities;
using System;
using System.Collections.Immutable;
using System.Linq.Expressions;

namespace DDD_Template.Domain.Base.Repositories
{
    public interface IRepository<T> where T : IAggregateRoot
    {
        IImmutableList<T> GetAll();

        T GetById(Guid id);

        IImmutableList<T> FindAll(Expression<Func<T, bool>> predicate);
    }
}