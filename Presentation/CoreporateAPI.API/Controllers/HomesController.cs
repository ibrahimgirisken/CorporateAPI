using CorporateAPI.Application.Consts;
using CorporateAPI.Application.CustomAttributes;
using CorporateAPI.Application.Enums;
using CorporateAPI.Application.Features.Commands.Home.CreateHome;
using CorporateAPI.Application.Features.Commands.Home.RemoveHome;
using CorporateAPI.Application.Features.Commands.Home.UpdateHome;
using CorporateAPI.Application.Features.Queries.Home.GetAllHome;
using CorporateAPI.Application.Features.Queries.Home.GetByContentTypeHome;
using CorporateAPI.Application.Features.Queries.Home.GetByIdHome;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CoreporateAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomesController : ControllerBase
    {
        readonly IMediator _mediator;

        public HomesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Homes, ActionType = ActionType.Reading, Definition = "Get All Home")]
        public async Task<IActionResult> GetAllHome([FromQuery] GetAllHomeQueryRequest getAllHomeQueryRequest)
        {
            GetAllHomeQueryResponse response=await _mediator.Send(getAllHomeQueryRequest);
            return Ok(response.Homes);
        }

        [HttpGet("by-id")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Homes, ActionType = ActionType.Reading, Definition = "Get By Id Home")]
        public async Task<IActionResult> GetByIdHome([FromQuery] GetByIdHomeQueryRequest getByIdHomeQueryRequest)
        {
            GetByIdHomeQueryResponse response=await _mediator.Send(getByIdHomeQueryRequest);
            return Ok(response.home);
        }
        [HttpGet("Home/{ContentType}")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Homes, ActionType = ActionType.Reading, Definition = "Get By ContentType Home")]
        public async Task<IActionResult> CreateHome([FromRoute] GetByContentTypeHomeQueryRequest getByContentTypeHomeQueryRequest)
        {
            GetByContentTypeHomeQueryResponse response = await _mediator.Send(getByContentTypeHomeQueryRequest);
            return Ok(response.homeDTO);
        }
        [HttpPost("add")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Homes, ActionType = ActionType.Writing, Definition = "Create Home")]
        public async Task<IActionResult> CreateHome(CreateHomeCommandRequest createHomeCommandRequest)
        {
          CreateHomeCommandResponse response= await _mediator.Send(createHomeCommandRequest);
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut("update")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Homes, ActionType = ActionType.Updating, Definition = "Update Home")]
        public async Task<IActionResult> UpdateHome(UpdateHomeCommandRequest updateHomeCommandRequest)
        {
          UpdateHomeCommandResponse response= await _mediator.Send(updateHomeCommandRequest);
            return Ok(response);
        }
        [HttpDelete("delete")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Homes, ActionType = ActionType.Deleting, Definition = "Remove Home")]
        public async Task<IActionResult> RemoveHome([FromQuery] RemoveHomeCommandRequest removeHomeCommandRequest)
        {
           RemoveHomeCommandResponse response= await _mediator.Send(removeHomeCommandRequest);
            return Ok(response);
        }

    }
}
