using AutoMapper;
using EventBus.Messages.Events;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using User.Application.Features.Commands.CreateUser;
using User.Application.Features.Commands.DeleteUser;
using User.Application.Features.Commands.UpdateUser;
using User.Application.Features.Users.Queries.GetUsersList;

namespace User.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publishEndpoint;

        public UserController(IMediator mediator, IMapper mapper, IPublishEndpoint publishEndpoint)
        {
            _mediator = mediator;
            _mapper = mapper;
            _publishEndpoint = publishEndpoint;
        }

        [HttpGet(Name = "GetUsers")]
        [ProducesResponseType(typeof(IEnumerable<UsersVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<UsersVm>>> GetUsers(CancellationToken cancellationToken = default)
        {
            var query = new GetUsersListQuery();
            var users = await _mediator.Send(query, cancellationToken);
            return Ok(users);
        }

        [HttpPost(Name = "CreateUser")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<ActionResult> CreateUser([FromBody] CreateUserCommand command, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);

            var eventMessage = _mapper.Map<UserIntegrationEvent>(result);

            await _publishEndpoint.Publish(eventMessage);

            return Ok();
        }

        [HttpPut(Name = "UpdateUser")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateUser([FromBody] UpdateUserCommand command, CancellationToken cancellationToken = default)
        {
            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteUser")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteUser(int id, CancellationToken cancellationToken = default)
        {
            var command = new DeleteUserCommand() { Id = id };
            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }
    }
}
