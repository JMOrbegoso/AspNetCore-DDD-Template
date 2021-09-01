using DDD_Template.Domain.Base.Repositories;
using DDD_Template.Domain.Users.Entities;

namespace DDD_Template.Domain.Users.Repositories
{
    public interface IUsersRepository : IRepository<User>
    {
        void Add(User user);

        void Remove(User user);
    }
}