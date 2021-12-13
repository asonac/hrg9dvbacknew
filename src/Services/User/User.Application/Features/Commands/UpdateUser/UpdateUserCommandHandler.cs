using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using User.Application.Contracts.Persistence;
using User.Application.Exceptions;
using Entities = User.Domain.Entities;

namespace User.Application.Features.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly IUserRepository _userReporsitory;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateUserCommandHandler> _logger;

        public UpdateUserCommandHandler(IUserRepository userReporsitory, IMapper mapper, ILogger<UpdateUserCommandHandler> logger)
        {
            _userReporsitory = userReporsitory;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken = default)
        {
            var userToUpdate = await _userReporsitory.GetByIdAsync(request.Id, cancellationToken);

            if (userToUpdate == null)
            {
                _logger.LogError("User does not exist on database");
                throw new NotFoundException(nameof(Entities.User), request.Id);
            }

            _mapper.Map(request, userToUpdate, typeof(UpdateUserCommand), typeof(Entities.User));

            await _userReporsitory.UpdateAsync(userToUpdate, cancellationToken);

            return Unit.Value;
        }
    }
}

