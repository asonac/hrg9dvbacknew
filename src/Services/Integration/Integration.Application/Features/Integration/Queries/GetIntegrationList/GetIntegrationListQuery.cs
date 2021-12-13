using MediatR;
using System.Collections.Generic;

namespace Integration.Application.Features.Integration.Queries.GetIntegrationList
{
    public class GetIntegrationListQuery : IRequest<List<IntegrationsVm>>
    {
        public GetIntegrationListQuery()
        {
        }
    }
}
