using MediatR;
using Microsoft.AspNetCore.Mvc;
using SeekQ.MyConnections.Api.Application.Commands;
using SeekQ.MyConnections.Api.Application.Queries;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SeekQ.MyConnections.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ConnectionController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ConnectionController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        [Route("{idUser}/blockedusers")]
        [SwaggerOperation(Summary = "Get connections by user")]
        public async Task<IEnumerable<GetBlockedUsersrViewModel>> GetNotificationsByUser(
            [FromRoute] Guid idUser
        )
        {
            return await _mediator.Send(new GetBlockedUsersQueryHandler.Query(idUser));
        }

        [HttpPost]
        [Route("unblock")]
        [SwaggerOperation(Summary = "unblock user connection")]
        [SwaggerResponse((int)HttpStatusCode.OK, "User connection unblocked succesfully")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "Bad Request")]
        public async Task<bool> UnblockUser(
            [FromBody]UnblockUserCommandHandler.Command connection
        )
        {
            return await _mediator.Send(connection);
        }

        [HttpPost]
        [Route("block")]
        [SwaggerOperation(Summary = "block user connection")]
        [SwaggerResponse((int)HttpStatusCode.OK, "User connection blocked succesfully")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "Bad Request")]
        public async Task<bool> BlockUser(
            [FromBody]BlockUserCommandHandler.Command connection
        )
        {
            return await _mediator.Send(connection);
        }
    }
}
