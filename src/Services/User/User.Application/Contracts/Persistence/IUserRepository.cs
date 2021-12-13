using Entities = User.Domain.Entities;

namespace User.Application.Contracts.Persistence
{
    public interface IUserRepository : IAsyncRepository<Entities.User>
    {

    }
}
