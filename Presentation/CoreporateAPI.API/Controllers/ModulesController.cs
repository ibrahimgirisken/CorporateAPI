using CorporateAPI.Application.Features.Commands.Menu.CreateMenu;
using CorporateAPI.Application.Features.Commands.Menu.RemoveMenu;
using CorporateAPI.Application.Features.Commands.Menu.UpdateMenu;
using CorporateAPI.Application.Features.Queries;
using CorporateAPI.Application.Features.Queries.Menu.GetAllMenu;
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
        public async Task<IActionResult> Get([FromQuery]GetAllMenuQueryRequest getAllMenuQueryRequest)
        {
            GetAllMenuQueryResponse response=await _mediator.Send(getAllMenuQueryRequest);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateMenuCommandRequest createMenuCommandRequest)
        {
            CreateMenuCommandResponse response=await _mediator.Send(createMenuCommandRequest);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateMenuCommandRequest updateMenuCommandRequest)
        {
            UpdateMenuCommandResponse response=await _mediator.Send(updateMenuCommandRequest);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute]RemoveMenuCommandRequest removeMenuCommandRequest)
        {
            RemoveMenuCommandResponse response=await _mediator.Send(removeMenuCommandRequest);
            return Ok(response);
        }
    }
}
