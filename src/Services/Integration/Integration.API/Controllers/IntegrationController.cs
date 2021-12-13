
using Integration.Application.Features.Commands.CreateIntegration;
using Integration.Application.Features.Commands.DeleteIntegration;
using Integration.Application.Features.Commands.UpdateIntegration;
using Integration.Application.Features.Integration.Queries.GetIntegrationList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Integration.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class IntegrationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public IntegrationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetIntegrations")]
        [ProducesResponseType(typeof(IEnumerable<IntegrationsVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<IntegrationsVm>>> GetIntegrations(CancellationToken cancellationToken = default)
        {
            var query = new GetIntegrationListQuery();
            var integrations = await _mediator.Send(query, cancellationToken);

            return Ok(integrations);
        }

        [HttpPost(Name = "CreateIntegration")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateIntegration([FromBody] CreateIntegrationCommand command, CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(result);
        }

        [HttpPut(Name = "UpdateIntegration")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateIntegration([FromBody] UpdateIntegrationCommand command, CancellationToken cancellationToken = default)
        {
            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteIntegration")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteIntegration(int id, CancellationToken cancellationToken = default)
        {
            var command = new DeleteIntegrationCommand() { Id = id };
            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }

    }
}
