using AutoMapper;
using Integration.Application.Features.Commands.CreateIntegration;
using Integration.Application.Features.Commands.DeleteIntegration;
using Integration.Application.Features.Commands.UpdateIntegration;
using Integration.Application.Features.Integration.Queries.GetIntegrationList;
using Integration.Application.Features.Integration.Queries.GetNewestIntegrationConfiguration;
using Entities = Integration.Domain.Entities;

namespace Integration.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Entities.Integration, IntegrationsVm>().ReverseMap();
            CreateMap<Entities.Integration, IntegrationVm>().ReverseMap();
            CreateMap<Entities.Integration, CreateIntegrationCommand>().ReverseMap();
            CreateMap<Entities.Integration, UpdateIntegrationCommand>().ReverseMap();
            CreateMap<Entities.Integration, DeleteIntegrationCommand>().ReverseMap();
        }
    }
}
