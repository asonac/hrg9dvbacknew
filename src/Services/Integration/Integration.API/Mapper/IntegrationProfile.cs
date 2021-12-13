using AutoMapper;
using EventBus.Messages.Events;
using Integration.Application.Features.Commands.IntegrateUser;
using Integration.Application.Features.Integration.Queries.GetNewestIntegrationConfiguration;

namespace Integration.API.Mapper
{
    public class IntegrationProfile : Profile
    {
        public IntegrationProfile()
        {
            CreateMap<IntegrateUserCommand, IntegrationVm>().ReverseMap();
            CreateMap<IntegrateUserCommand, UserIntegrationEvent>().ReverseMap();
        }
    }
}
