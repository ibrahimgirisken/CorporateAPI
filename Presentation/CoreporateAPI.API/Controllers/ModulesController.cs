using CorporateAPI.Application.Features.Commands.Menu.CreateMenu;
using CorporateAPI.Application.Features.Commands.Menu.RemoveMenu;
using CorporateAPI.Application.Features.Commands.Menu.UpdateMenu;
using CorporateAPI.Application.Features.Commands.Module.CreateModule;
using CorporateAPI.Application.Features.Commands.Module.RemoveModule;
using CorporateAPI.Application.Features.Commands.Module.UpdateModule;
using CorporateAPI.Application.Features.Queries;
using CorporateAPI.Application.Features.Queries.Menu.GetAllMenu;
using CorporateAPI.Application.Features.Queries.Module.GetAllModule;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreporateAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes ="Admin")]
    public class ModulesController : ControllerBase
    {
        readonly IMediator _mediator;

        public ModulesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]GetAllModuleQueryRequest getAllModuleQueryRequest)
        {
            GetAllModuleQueryResponse response=await _mediator.Send(getAllModuleQueryRequest);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateModuleCommandRequest createModuleCommandRequest)
        {
            CreateModuleCommandResponse response=await _mediator.Send(createModuleCommandRequest);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateModuleCommandRequest updateModuleCommandRequest)
        {
            UpdateModuleCommandResponse response=await _mediator.Send(updateModuleCommandRequest);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute]RemoveModuleCommandRequest removeModuleCommandRequest)
        {
            RemoveModuleCommandResponse response=await _mediator.Send(removeModuleCommandRequest);
            return Ok(response);
        }
    }
}
