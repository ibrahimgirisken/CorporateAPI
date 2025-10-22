using CorporateAPI.Application.Consts;
using CorporateAPI.Application.CustomAttributes;
using CorporateAPI.Application.Enums;
using CorporateAPI.Application.Features.Commands.Datasheet.CreateDatasheet;
using CorporateAPI.Application.Features.Commands.Datasheet.RemoveDatasheet;
using CorporateAPI.Application.Features.Commands.Datasheet.UpdateDatasheet;
using CorporateAPI.Application.Features.Queries.Datasheet.GetAllDatasheet;
using CorporateAPI.Application.Features.Queries.Datasheet.GetByIdDatasheet;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CoreporateAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatasheetsController : ControllerBase
    {
        readonly IMediator _mediator;

        public DatasheetsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Datasheets, ActionType = ActionType.Reading, Definition = "Get All Datasheet")]
        public async Task<IActionResult> GetAllDatasheet([FromQuery] GetAllDatasheetQueryRequest getAllDatasheetQueryRequest)
        {
            GetAllDatasheetQueryResponse response=await _mediator.Send(getAllDatasheetQueryRequest);
            return Ok(response.resultDatasheetsDto);
        }

        [HttpGet("by-id")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Datasheets, ActionType = ActionType.Reading, Definition = "Get By Id Datasheet")]
        public async Task<IActionResult> GetByIdDatasheet([FromQuery] GetByIdDatasheetQueryRequest getByIdDatasheetQueryRequest)
        {
            GetByIdDatasheetQueryResponse response=await _mediator.Send(getByIdDatasheetQueryRequest);
            return Ok(response.ResultDatasheetDTO);
        }

        [HttpPost("add")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Datasheets, ActionType = ActionType.Writing, Definition = "Create Datasheet")]
        public async Task<IActionResult> CreateDatasheet(CreateDatasheetCommandRequest createDatasheetCommandRequest)
        {
            CreateDatasheetCommandResponse response=await _mediator.Send(createDatasheetCommandRequest);
            return StatusCode((int) HttpStatusCode.Created);
        }

        [HttpPut("update")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Datasheets, ActionType = ActionType.Updating, Definition = "Update Datasheet")]
        public async Task<IActionResult> UpdateDatasheet(UpdateDatasheetCommandRequest updateDatasheetCommandRequest)
        {
            UpdateDatasheetCommandResponse response = await _mediator.Send(updateDatasheetCommandRequest);
             return Ok(response);
        }
        [HttpDelete("delete")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Datasheets, ActionType = ActionType.Deleting, Definition = "Remove Datasheet")]
        public async Task<IActionResult> RemoveDatasheet([FromRoute] RemoveDatasheetCommandRequest removeDatasheetCommandRequest)
        {
            RemoveDatasheetCommandResponse response=await _mediator.Send(removeDatasheetCommandRequest);
            return Ok(response);
        }
    }
}
