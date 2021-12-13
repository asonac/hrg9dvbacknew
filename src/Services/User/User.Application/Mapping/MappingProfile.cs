using AutoMapper;
using User.Application.Features.Commands.CreateUser;
using User.Application.Features.Commands.DeleteUser;
using User.Application.Features.Commands.UpdateUser;
using User.Application.Features.Users.Queries.GetUsersList;
using User.Application.Model;
using Entities = User.Domain.Entities;

namespace User.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Entities.User, UsersVm>().ReverseMap();
            CreateMap<Entities.User, UserDto>().ReverseMap();
            CreateMap<Entities.User, CreateUserCommand>().ReverseMap();
            CreateMap<Entities.User, UpdateUserCommand>().ReverseMap();
            CreateMap<Entities.User, DeleteUserCommand>().ReverseMap();
        }
    }
}
