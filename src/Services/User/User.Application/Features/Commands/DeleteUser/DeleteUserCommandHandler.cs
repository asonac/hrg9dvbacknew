using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using User.Application.Contracts.Persistence;
using User.Application.Exceptions;
using Entities = User.Domain.Entities;

namespace User.Application.Features.Commands.DeleteUser
{
    class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly IUserRepository _userReporsitory;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteUserCommandHandler> _logger;

        public DeleteUserCommandHandler(IUserRepository userReporsitory, IMapper mapper, ILogger<DeleteUserCommandHandler> logger)
        {
            _userReporsitory = userReporsitory;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken = default)
        {
            var userToDelete = await _userReporsitory.GetByIdAsync(request.Id, cancellationToken);

            if (userToDelete == null)
            {
                _logger.LogError("User does not exist on database");
                throw new NotFoundException(nameof(Entities.User), request.Id);
            }
            await _userReporsitory.DeleteAsync(userToDelete, cancellationToken);

            return Unit.Value;
        }
    }
}
