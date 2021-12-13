using AutoMapper;
using Integration.Application.Contracts.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Integration.Application.Features.Integration.Queries.GetIntegrationList
{
    public class GetIntegrationListQueryHandler : IRequestHandler<GetIntegrationListQuery, List<IntegrationsVm>>
    {
        private readonly IIntegrationRepository _integrationReporsitory;
        private readonly IMapper _mapper;
        private readonly ILogger<GetIntegrationListQueryHandler> _logger;

        public GetIntegrationListQueryHandler(IIntegrationRepository integrationReporsitory, IMapper mapper, ILogger<GetIntegrationListQueryHandler> logger)
        {
            _integrationReporsitory = integrationReporsitory;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<IntegrationsVm>> Handle(GetIntegrationListQuery request, CancellationToken cancellationToken = default)
        {
            var integrationList = await _integrationReporsitory.GetAllAsync(cancellationToken);
            return _mapper.Map<List<IntegrationsVm>>(integrationList);
        }
    }
}
