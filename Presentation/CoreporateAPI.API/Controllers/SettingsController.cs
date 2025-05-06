using CorporateAPI.Application.Consts;
using CorporateAPI.Application.CustomAttributes;
using CorporateAPI.Application.Enums;
using CorporateAPI.Application.Features.Commands.Settting.CreateSetting;
using CorporateAPI.Application.Features.Commands.Settting.UpdateSetting;
using CorporateAPI.Application.Features.Queries.Setting.GetByIdSetting;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CoreporateAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : ControllerBase
    {
        readonly IMediator _mediator;

        public SettingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("by-id")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Settings, ActionType = ActionType.Reading, Definition = "Get By Id Setting")]

        public async Task<IActionResult> GetByIdSetting([FromQuery] GetByIdSettingQueryRequest getByIdSettingQueryRequest)
        {
            GetByIdSettingQueryResponse response = await _mediator.Send(getByIdSettingQueryRequest);
            return Ok(response.Settings);
        }

        [HttpPost("add")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Settings, ActionType = ActionType.Writing, Definition = "Create Setting")]

        public async Task<IActionResult> CreateSetting(CreateSettingCommandRequest createSettingCommandRequest)
        {
            CreateSettingCommandResponse response = await _mediator.Send(createSettingCommandRequest);
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut("update")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Settings, ActionType = ActionType.Updating, Definition = "Update Setting")]

        public async Task<IActionResult> RemoveSetting(UpdateSettingCommandRequest updateSettingCommandRequest)
        {
            UpdateSettingCommandResponse response = await _mediator.Send(updateSettingCommandRequest);
            return Ok(response);
        }
    }
}
