using DDD_Template.Domain.Users.Entities;
using DDD_Template.Domain.Users.Repositories;
using DDD_Template.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Immutable;
using System.Linq;
using System.Linq.Expressions;

namespace DDD_Template.Infrastructure.Repositories
{
    public sealed class UsersRepository : IUsersRepository
    {
        private DbSet<User> _dbSet { get; }

        public UsersRepository(ApplicationDbContext context)
        {
            this._dbSet = context.Set<User>();
        }

        public IImmutableList<User> GetAll()
        {
            return this._dbSet.ToImmutableList();
        }

        public User GetById(Guid id)
        {
            return this._dbSet.Find(id);
        }

        public IImmutableList<User> FindAll(Expression<Func<User, bool>> predicate)
        {
            return this._dbSet.Where(predicate).ToImmutableList();
        }

        public void Add(User user)
        {
            this._dbSet.Add(user);
        }

        public void Remove(User user)
        {
            this._dbSet.Remove(user);
        }
    }
}