using CorporateAPI.Application.Features.Commands.Module.CreateModule;
using CorporateAPI.Application.Features.Commands.Module.RemoveModule;
using CorporateAPI.Application.Features.Commands.Module.UpdateModule;
using CorporateAPI.Application.Features.Queries.Menu.GetAllMenu;
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

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]GetAllModuleQueryRequest getAllModuleQueryRequest)
        {
            var includeAllLanguages = Request.Query["IncludeAllLanguages"].ToString();
            bool includeAllLanguagesFlag = includeAllLanguages.Equals("true", StringComparison.OrdinalIgnoreCase);
            string language = Request.Headers["Accept-Language".ToString()];
            if (string.IsNullOrEmpty(language))
            {
                language = "en"; // Varsayılan dil
            }
            getAllModuleQueryRequest.Language = language;
            getAllModuleQueryRequest.IncludeAllLanguages = includeAllLanguagesFlag;
            GetAllModuleQueryResponse response = await _mediator.Send(getAllModuleQueryRequest);
            return Ok(response.ModulesDto);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> Get([FromRoute] GetByIdModuleQueryRequest getByIdModuleQueryRequest)
        {
            GetByIdModuleQueryResponse response=await _mediator.Send(getByIdModuleQueryRequest);
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
