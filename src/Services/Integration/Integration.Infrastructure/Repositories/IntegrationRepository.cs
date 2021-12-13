using Integration.Application.Contracts.Persistence;
using Integration.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Entities = Integration.Domain.Entities;

namespace Integration.Infrastructure.Repositories
{
    public class IntegrationRepository : RepositoryBase<Entities.Integration>, IIntegrationRepository
    {
        public IntegrationRepository(Context dbContext) : base(dbContext)
        {
        }

        public async Task<Entities.Integration> GetNewestIntegration(CancellationToken cancellationToken = default)
        {
            var integration = await _dbContext.Integrations.OrderByDescending(x => x.Id).FirstOrDefaultAsync(cancellationToken);
            return integration;
        }
    }
}
