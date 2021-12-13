using MediatR;

namespace Integration.Application.Features.Integration.Queries.GetNewestIntegrationConfiguration
{
    public class GetNewestIntegrationConfigurationQuery : IRequest<IntegrationVm>
    {
        public GetNewestIntegrationConfigurationQuery()
        {
        }
    }
}
