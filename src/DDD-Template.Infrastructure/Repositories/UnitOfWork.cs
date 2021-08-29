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
        private ApplicationDbContext _applicationDbContext { get; }
        private IDomainEventDispatcher _dispatcher { get; }

        public IUsersRepository UsersRepository { get; }

        public UnitOfWork(ApplicationDbContext applicationDbContext, IDomainEventDispatcher dispatcher)
        {
            this._applicationDbContext = applicationDbContext;
            this._dispatcher = dispatcher;

            this.UsersRepository = new UsersRepository(applicationDbContext);
        }

        public async Task<int> CommitChangesAsync()
        {
            await this.dispatchDomainEvents();
            return await this._applicationDbContext.SaveChangesAsync();
        }

        private async Task dispatchDomainEvents()
        {
            var changeTracker = this._applicationDbContext.ChangeTracker;

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
            this._applicationDbContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}