using System.Threading;
using System.Threading.Tasks;
using Entities = Integration.Domain.Entities;

namespace Integration.Application.Contracts.Persistence
{
    public interface IIntegrationRepository : IAsyncRepository<Entities.Integration>
    {
        Task<Entities.Integration> GetNewestIntegration(CancellationToken cancellationToken = default);
    }
}
