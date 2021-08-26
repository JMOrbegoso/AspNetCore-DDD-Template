using DDD_Template.Domain.Users.Repositories;
using System;
using System.Threading.Tasks;

namespace DDD_Template.Domain.Base.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IUsersRepository UsersRepository { get; }

        Task CommitAsync();
    }
}