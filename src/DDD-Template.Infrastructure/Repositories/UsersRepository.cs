using DDD_Template.Domain.Users.Entities;
using DDD_Template.Domain.Users.Repositories;
using DDD_Template.Infrastructure.Persistence.Contexts;

namespace DDD_Template.Infrastructure.Repositories
{
    public class UsersRepository : GenericRepository<User>, IUsersRepository
    {
        public UsersRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}