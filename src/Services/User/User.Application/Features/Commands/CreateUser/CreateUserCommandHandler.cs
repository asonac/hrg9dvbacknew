using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using User.Application.Contracts.Persistence;
using User.Application.Model;
using Entities = User.Domain.Entities;

namespace User.Application.Features.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserDto>
    {
        private readonly IUserRepository _userReporsitory;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateUserCommandHandler> _logger;

        public CreateUserCommandHandler(IUserRepository userReporsitory, IMapper mapper, ILogger<CreateUserCommandHandler> logger)
        {
            _userReporsitory = userReporsitory;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken = default)
        {
            var userEntity = _mapper.Map<Entities.User>(request);

            var newUser = await _userReporsitory.AddAsync(userEntity, cancellationToken);

            _logger.LogInformation($"User was successfully created.");

            return _mapper.Map<UserDto>(newUser);
        }
    }
}
