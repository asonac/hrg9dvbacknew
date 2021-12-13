using AutoMapper;
using EventBus.Messages.Events;
using Integration.Application.Features.Commands.IntegrateUser;
using Integration.Application.Features.Integration.Queries.GetNewestIntegrationConfiguration;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Integration.API.EventBusConsumer
{
    public class UserIntegrationConsumer : IConsumer<UserIntegrationEvent>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly ILogger<UserIntegrationConsumer> _logger;

        public UserIntegrationConsumer(IMapper mapper, IMediator mediator, ILogger<UserIntegrationConsumer> logger)
        {
            _mapper = mapper;
            _mediator = mediator;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<UserIntegrationEvent> context)
        {
            var message = context.Message;

            var integratiomConfigQuery = new GetNewestIntegrationConfigurationQuery();
            var integrationConfig = await _mediator.Send(integratiomConfigQuery);

            var command = new IntegrateUserCommand();

            _mapper.Map(integrationConfig, command, typeof(IntegrationVm), typeof(IntegrateUserCommand));
            _mapper.Map(message, command, typeof(UserIntegrationEvent), typeof(IntegrateUserCommand));

            await _mediator.Send(command);

            _logger.LogInformation("User integration consumed successfully.");
        }
    }
}
