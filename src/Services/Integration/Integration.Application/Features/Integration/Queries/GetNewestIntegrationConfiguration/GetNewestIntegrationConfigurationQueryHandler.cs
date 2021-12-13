using AutoMapper;
using Integration.Application.Contracts.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Integration.Application.Features.Integration.Queries.GetNewestIntegrationConfiguration
{
    public class GetNewestIntegrationConfigurationQueryHandler : IRequestHandler<GetNewestIntegrationConfigurationQuery, IntegrationVm>
    {
        private readonly IIntegrationRepository _integrationReporsitory;
        private readonly IMapper _mapper;
        private readonly ILogger<GetNewestIntegrationConfigurationQueryHandler> _logger;

        public GetNewestIntegrationConfigurationQueryHandler(IIntegrationRepository integrationReporsitory, IMapper mapper, ILogger<GetNewestIntegrationConfigurationQueryHandler> logger)
        {
            _integrationReporsitory = integrationReporsitory;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IntegrationVm> Handle(GetNewestIntegrationConfigurationQuery request, CancellationToken cancellationToken = default)
        {
            var integration = await _integrationReporsitory.GetNewestIntegration(cancellationToken);
            var result = _mapper.Map<IntegrationVm>(integration);
            return result;
        }
    }
}
