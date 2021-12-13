using MediatR;
using System.Collections.Generic;

namespace User.Application.Features.Users.Queries.GetUsersList
{
    public class GetUsersListQuery : IRequest<List<UsersVm>>
    {
        public GetUsersListQuery()
        {
        }
    }
}
