using CorporateAPI.Application.Consts;
using CorporateAPI.Application.CustomAttributes;
using CorporateAPI.Application.Enums;
using CorporateAPI.Application.Features.Commands.Lang.CreateLang;
using CorporateAPI.Application.Features.Commands.Lang.RemoveLang;
using CorporateAPI.Application.Features.Commands.Lang.UpdateLang;
using CorporateAPI.Application.Features.Queries.Lang.GetAllLang;
using CorporateAPI.Application.Features.Queries.Lang.GetByIdLang;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CoreporateAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LangsController : ControllerBase
    {
        readonly IMediator _mediator;

        public LangsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Langs, ActionType = ActionType.Reading, Definition = "Get All Lang")]
        public async Task<IActionResult> GetAllLang([FromQuery] GetAllLangRequest getAllLangRequest)
        {
            GetAllLangResponse response = await _mediator.Send(getAllLangRequest);
            return Ok(response.LangData);
        }

        [HttpGet("by-id")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Langs, ActionType = ActionType.Reading, Definition = "Get By Id Lang")]
        public async Task<IActionResult> GetByIdLang([FromQuery] GetByIdLangRequest getByIdLangRequest)
        {
            GetByIdLangResponse response = await _mediator.Send(getByIdLangRequest);
            return Ok(response.Lang);
        }

        [HttpPost("add")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Langs, ActionType = ActionType.Writing, Definition = "Create Lang")]
        public async Task<IActionResult> CreateLang(CreateLangCommandRequest createLangRequest)
        {
            CreateLangResponse response = await _mediator.Send(createLangRequest);
            return Ok(response);
        }

        [HttpPut("update")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Langs, ActionType = ActionType.Updating, Definition = "Update Lang")]
        public async Task<IActionResult> UpdateLang(UpdateLangCommandRequest updateLangRequest)
        {
            UpdateLangCommandResponse response = await _mediator.Send(updateLangRequest);
            return Ok(response);
        }
        [HttpDelete("delete")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Langs, ActionType = ActionType.Deleting, Definition = "Remove Lang")]
        public async Task<IActionResult> RemoveLang([FromQuery] RemoveLangCommandRequest removeLangRequest)
        {
            RemoveLangCommandResponse response = await _mediator.Send(removeLangRequest);
            return Ok(response);
        }
    }
}
