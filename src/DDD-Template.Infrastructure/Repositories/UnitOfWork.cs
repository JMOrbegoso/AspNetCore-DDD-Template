using DDD_Template.Domain.Base.Repositories;
using DDD_Template.Domain.Users.Repositories;
using DDD_Template.Infrastructure.Persistence.Contexts;
using System;
using System.Threading.Tasks;

namespace DDD_Template.Infrastructure.Repositories
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _applicationDbContext { get; }

        public IUsersRepository UsersRepository { get; }

        public UnitOfWork(ApplicationDbContext applicationDbContext)
        {
            this._applicationDbContext = applicationDbContext;

            this.UsersRepository = new UsersRepository(applicationDbContext);
        }

        public async Task<int> CommitChangesAsync()
        {
            return await this._applicationDbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            this._applicationDbContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}