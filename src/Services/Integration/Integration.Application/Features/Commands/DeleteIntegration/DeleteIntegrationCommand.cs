using MediatR;

namespace Integration.Application.Features.Commands.DeleteIntegration
{
    public class DeleteIntegrationCommand : IRequest
    {
        public int Id { get; set; }
    }
}
