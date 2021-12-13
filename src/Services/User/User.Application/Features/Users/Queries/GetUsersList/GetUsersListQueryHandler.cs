using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using User.Application.Contracts.Persistence;

namespace User.Application.Features.Users.Queries.GetUsersList
{
    public class GetUsersListQueryHandler : IRequestHandler<GetUsersListQuery, List<UsersVm>>
    {
        private readonly IUserRepository _userReporsitory;
        private readonly IMapper _mapper;
        private readonly ILogger<GetUsersListQueryHandler> _logger;

        public GetUsersListQueryHandler(IUserRepository userReporsitory, IMapper mapper, ILogger<GetUsersListQueryHandler> logger)
        {
            _userReporsitory = userReporsitory;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<UsersVm>> Handle(GetUsersListQuery request, CancellationToken cancellationToken = default)
        {
            var userList = await _userReporsitory.GetAllAsync(cancellationToken);
            return _mapper.Map<List<UsersVm>>(userList);
        }
    }
}
