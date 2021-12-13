using AutoMapper;
using Integration.Application.Contracts.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using Entities = Integration.Domain.Entities;

namespace Integration.Application.Features.Commands.CreateIntegration
{
    public class CreateIntegrationHandler : IRequestHandler<CreateIntegrationCommand, int>
    {
        private readonly IIntegrationRepository _integrationReporsitory;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateIntegrationHandler> _logger;

        public CreateIntegrationHandler(IIntegrationRepository integrationReporsitory, IMapper mapper, ILogger<CreateIntegrationHandler> logger)
        {
            _integrationReporsitory = integrationReporsitory;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(CreateIntegrationCommand request, CancellationToken cancellationToken = default)
        {
            var integrationEntity = _mapper.Map<Entities.Integration>(request);

            var newIntegration = await _integrationReporsitory.AddAsync(integrationEntity, cancellationToken);

            _logger.LogInformation($"Integration configuration was successfully created.");

            return newIntegration.Id;
        }
    }
}
