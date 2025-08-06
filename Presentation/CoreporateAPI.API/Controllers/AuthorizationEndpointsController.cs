using CorporateAPI.Application.Features.Commands.AuthorizationEndpoint.AssignRoleEndpoint;
using CorporateAPI.Application.Features.Queries.AuthorizationEndpoint.GetRolesToEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CoreporateAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationEndpointsController : ControllerBase
    {
        readonly IMediator _mediator;

        public AuthorizationEndpointsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("action")]
        public async Task<IActionResult> GetRolesToEndpoint(GetRolesToEndpointQueryRequest getRolesToEndpoint)
        {
            GetRolesToEndpointQueryResponse response= await _mediator.Send(getRolesToEndpoint);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AssignRoleEndpoint(AssignRoleEndpointCommandRequest assignRoleEndpointCommandRequest)
        {
            assignRoleEndpointCommandRequest.Type = typeof(Program);
            AssignRoleEndpointCommandResponse response=await _mediator.Send(assignRoleEndpointCommandRequest);
            return Ok(response);
        }
    }
}
