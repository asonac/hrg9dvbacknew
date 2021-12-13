using AutoMapper;
using EventBus.Messages.Events;
using User.Application.Model;

namespace User.API.Mapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserIntegrationEvent, UserDto>().ReverseMap();
        }
    }
}
