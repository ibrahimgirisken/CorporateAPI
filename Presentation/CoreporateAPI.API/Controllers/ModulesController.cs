using CorporateAPI.Application.Consts;
using CorporateAPI.Application.CustomAttributes;
using CorporateAPI.Application.Enums;
using CorporateAPI.Application.Features.Commands.Module.CreateModule;
using CorporateAPI.Application.Features.Commands.Module.RemoveModule;
using CorporateAPI.Application.Features.Commands.Module.UpdateModule;
using CorporateAPI.Application.Features.Queries.Module.GetAllModule;
using CorporateAPI.Application.Features.Queries.Module.GetByIdModule;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CoreporateAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes ="Admin")]
    public class ModulesController : ControllerBase
    {
        readonly IMediator _mediator;

        public ModulesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Modules, ActionType = ActionType.Reading, Definition = "Get All Module")]
        public async Task<IActionResult> GetAllModule([FromQuery]GetAllModuleQueryRequest getAllModuleQueryRequest)
        {
            var includeAllLanguages = Request.Query["IncludeAllLanguages"].ToString();
            bool includeAllLanguagesFlag = includeAllLanguages.Equals("true", StringComparison.OrdinalIgnoreCase);
            getAllModuleQueryRequest.IncludeAllLanguages = includeAllLanguagesFlag;
            GetAllModuleQueryResponse response = await _mediator.Send(getAllModuleQueryRequest);
            return Ok(response.ModulesDto);
        }
        [HttpGet("by-id")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Modules, ActionType = ActionType.Reading, Definition = "Get By Id Module")]
        public async Task<IActionResult> GetByIdModule([FromQuery] GetByIdModuleQueryRequest getByIdModuleQueryRequest)
        {
            GetByIdModuleQueryResponse response=await _mediator.Send(getByIdModuleQueryRequest);
            return Ok(response.Module);
        }

        [HttpPost("add")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Modules, ActionType = ActionType.Writing, Definition = "Create Module")]
        public async Task<IActionResult> CreateModule(CreateModuleCommandRequest createModuleCommandRequest)
        {
            CreateModuleCommandResponse response=await _mediator.Send(createModuleCommandRequest);
            return Ok(response);
        }

        [HttpPut("update")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Modules, ActionType = ActionType.Updating, Definition = "Update Module")]
        public async Task<IActionResult> UpdateModule(UpdateModuleCommandRequest updateModuleCommandRequest)
        {
            UpdateModuleCommandResponse response=await _mediator.Send(updateModuleCommandRequest);
            return Ok(response);
        }

        [HttpDelete("delete")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Modules, ActionType = ActionType.Deleting, Definition = "Remove Module")]
        public async Task<IActionResult> RemoveModule([FromRoute]RemoveModuleCommandRequest removeModuleCommandRequest)
        {
            RemoveModuleCommandResponse response=await _mediator.Send(removeModuleCommandRequest);
            return Ok(response);
        }
    }
}
