using AutoMapper;
using Integration.Application.Contracts.Persistence;
using Integration.Application.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using Entities = Integration.Domain.Entities;

namespace Integration.Application.Features.Commands.DeleteIntegration
{
    public class DeleteIntegrationHandler : IRequestHandler<DeleteIntegrationCommand>
    {
        private readonly IIntegrationRepository _integrationReporsitory;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteIntegrationHandler> _logger;

        public DeleteIntegrationHandler(IIntegrationRepository integrationReporsitory, IMapper mapper, ILogger<DeleteIntegrationHandler> logger)
        {
            _integrationReporsitory = integrationReporsitory;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteIntegrationCommand request, CancellationToken cancellationToken)
        {
            var integrationToDelete = await _integrationReporsitory.GetByIdAsync(request.Id, cancellationToken);

            if (integrationToDelete == null)
            {
                _logger.LogError("Integration configuration does not exist on database");
                throw new NotFoundException(nameof(Entities.Integration), request.Id);
            }
            await _integrationReporsitory.DeleteAsync(integrationToDelete, cancellationToken);

            return Unit.Value;
        }
    }
}
