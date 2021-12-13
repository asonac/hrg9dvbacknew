using AutoMapper;
using Integration.Application.Contracts.Persistence;
using Integration.Application.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using Entities = Integration.Domain.Entities;

namespace Integration.Application.Features.Commands.UpdateIntegration
{
    public class UpdateIntegrationHandler : IRequestHandler<UpdateIntegrationCommand>
    {
        private readonly IIntegrationRepository _integrationReporsitory;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateIntegrationHandler> _logger;

        public UpdateIntegrationHandler(IIntegrationRepository integrationReporsitory, IMapper mapper, ILogger<UpdateIntegrationHandler> logger)
        {
            _integrationReporsitory = integrationReporsitory;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateIntegrationCommand request, CancellationToken cancellationToken)
        {
            var integrationToUpdate = await _integrationReporsitory.GetByIdAsync(request.Id, cancellationToken);

            if (integrationToUpdate == null)
            {
                _logger.LogError("Integration configuration does not exist on database");
                throw new NotFoundException(nameof(Entities.Integration), request.Id);
            }

            _mapper.Map(request, integrationToUpdate, typeof(UpdateIntegrationCommand), typeof(Entities.Integration));

            await _integrationReporsitory.UpdateAsync(integrationToUpdate, cancellationToken);

            return Unit.Value;
        }
    }
}
