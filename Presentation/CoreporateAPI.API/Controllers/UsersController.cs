using CorporateAPI.Application.Consts;
using CorporateAPI.Application.CustomAttributes;
using CorporateAPI.Application.Enums;
using CorporateAPI.Application.Features.Commands.AppUser.CreateUser;
using CorporateAPI.Application.Features.Commands.AppUser.LoginUser;
using CorporateAPI.Application.Features.Commands.AuthorizationEndpoint.AssignRoleEndpoint;
using CorporateAPI.Application.Features.Queries.AppUser.GetAllUsers;
using CorporateAPI.Application.Features.Queries.AppUser.GetRolesToUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreporateAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet()]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Users, ActionType = ActionType.Reading, Definition = "Get All Users")]
        public async Task<IActionResult> GetAllUsers([FromQuery]GetAllUsersQueryRequest getAllUsersQueryRequest)
        {
            GetAllUsersQueryResponse response = await _mediator.Send(getAllUsersQueryRequest);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserCommandRequest createUserCommandRequest)
        {
           CreateUserCommandResponse response=await _mediator.Send(createUserCommandRequest);
            return Ok(response);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginUserCommandRequest loginUserCommandRequest)
        {
            LoginUserCommandResponse response = await _mediator.Send(loginUserCommandRequest);
            return Ok(response);
        }

        [HttpGet("get-roles-to-user/{UserId}")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Users, ActionType = ActionType.Reading, Definition = "Get Roles To User")]
        public async Task<IActionResult> GetRolesToUser([FromRoute] GetRolesToUserRequest getRolesToUserRequest)
        {
            GetRolesToUserResponse response = await _mediator.Send(getRolesToUserRequest);
            return Ok(response);
        }

        [HttpPost("assign-role-to-user")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Users, ActionType = ActionType.Writing, Definition = "Assign Role To User")]
        public async Task<IActionResult> AssignRoleToUser(AssignRoleEndpointCommandRequest roleEndpointCommandRequest)
        {
            AssignRoleEndpointCommandResponse response=await _mediator.Send(roleEndpointCommandRequest);
            return Ok(response);
        }

    }
}
