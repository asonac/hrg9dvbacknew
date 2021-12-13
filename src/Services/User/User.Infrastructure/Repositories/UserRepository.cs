using User.Application.Contracts.Persistence;
using User.Infrastructure.Persistence;
using Entities = User.Domain.Entities;

namespace User.Infrastructure.Data.SqlServer.Repositories
{

    public class UserRepository : RepositoryBase<Entities.User>, IUserRepository
    {
        public UserRepository(Context dbContext) : base(dbContext)
        {
        }


    }
}
