using MediatR;
using User.Application.Model;

namespace User.Application.Features.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<UserDto>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public string EmailAddress { get; set; }
    }
}
