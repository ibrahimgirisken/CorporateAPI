using CorporateAPI.Application.Consts;
using CorporateAPI.Application.CustomAttributes;
using CorporateAPI.Application.Enums;
using CorporateAPI.Application.Features.Commands.Role.CreateRole;
using CorporateAPI.Application.Features.Commands.Role.RemoveRole;
using CorporateAPI.Application.Features.Commands.Role.UpdateRole;
using CorporateAPI.Application.Features.Queries.Role.GetAllRole;
using CorporateAPI.Application.Features.Queries.Role.GetByIdRole;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreporateAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class RolesController : ControllerBase
    {
        readonly IMediator _mediator;

        public RolesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        [AuthorizeDefinition(ActionType =ActionType.Reading,Definition ="Get By Id Role",Menu = AuthorizeDefinitionConstants.Roles)]
        public async Task<IActionResult> GetByIdRole([FromRoute]GetByIdRoleQueryRequest getByIdRoleQueryRequest)
        {
            GetByIdRoleQueryResponse response = await _mediator.Send(getByIdRoleQueryRequest);
            return Ok(response);
        }
        [HttpGet]
        [AuthorizeDefinition(ActionType = ActionType.Reading, Definition = "Get Roles", Menu = AuthorizeDefinitionConstants.Roles)]
        public async Task<IActionResult> GetRoles([FromQuery] GetAllRoleQueryRequest getAllRoleQueryRequest)
        {
         GetAllRoleQueryResponse response=await _mediator.Send(getAllRoleQueryRequest);
            return Ok(response);
        }

        [HttpPost]
        [AuthorizeDefinition(ActionType = ActionType.Writing, Definition = "Create Role", Menu = AuthorizeDefinitionConstants.Roles)]
        public async Task<IActionResult> CreateRole([FromBody]CreateRoleCommandRequest createRoleCommandRequest)
        {
           CreateRoleCommandResponse response=await _mediator.Send(createRoleCommandRequest);
            return Ok(response);
        }
        [HttpPut("{Id}")]
        [AuthorizeDefinition(ActionType = ActionType.Updating, Definition = "Update Role", Menu = AuthorizeDefinitionConstants.Roles)]
        public async Task<IActionResult> UpdateRole([FromBody][FromRoute]UpdateRoleCommandRequest updateRoleCommandRequest)
        {
            UpdateRoleCommandResponse response=await _mediator.Send(updateRoleCommandRequest);
            return Ok(response);
        }
        [HttpDelete("{name}")]
        [AuthorizeDefinition(ActionType = ActionType.Deleting, Definition = "Remove Role", Menu = AuthorizeDefinitionConstants.Roles)]
        public async Task<IActionResult> RemoveRole([FromRoute]RemoveRoleCommandRequest removeRoleCommandRequest)
        {
            RemoveRoleCommandResponse response=await _mediator.Send(removeRoleCommandRequest);
            return Ok(response);
        }
    }
}
