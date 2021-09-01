using DDD_Template.Domain.Base.DomainEvents;
using DDD_Template.Domain.Base.Entities;
using DDD_Template.Domain.Base.Repositories;
using DDD_Template.Domain.Users.Repositories;
using DDD_Template.Infrastructure.Persistence.Contexts;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DDD_Template.Infrastructure.Repositories
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _context { get; }
        private IDomainEventDispatcher _dispatcher { get; }

        public IUsersRepository UsersRepository { get; }

        public UnitOfWork(ApplicationDbContext context, IDomainEventDispatcher dispatcher)
        {
            this._context = context;
            this._dispatcher = dispatcher;

            this.UsersRepository = new UsersRepository(context);
        }

        public async Task<int> CommitChangesAsync()
        {
            await this.dispatchDomainEvents();
            return await this._context.SaveChangesAsync();
        }

        private async Task dispatchDomainEvents()
        {
            var changeTracker = this._context.ChangeTracker;

            var domainEvents = changeTracker.Entries<IAggregateRoot>()
                                            .Select(e => e.Entity)
                                            .Where(e => e.DomainEvents.Any())
                                            .SelectMany(e => e.DomainEvents);

            foreach (var domainEvent in domainEvents)
            {
                await this._dispatcher.Dispatch(domainEvent);
            }
        }

        public void Dispose()
        {
            this._context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}