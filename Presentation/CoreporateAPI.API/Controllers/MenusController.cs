using CorporateAPI.Application.Features.Commands.Menu.CreateMenu;
using CorporateAPI.Application.Features.Commands.Menu.RemoveMenu;
using CorporateAPI.Application.Features.Queries.Menu.GetAllMenu;
using CorporateAPI.Application.Features.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using CorporateAPI.Application.Features.Commands.Menu.UpdateMenu;

namespace CoreporateAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenusController : ControllerBase
    {
        readonly IMediator _mediator;

        public MenusController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllMenuQueryRequest getAllMenuQueryRequest)
        {
            GetAllMenuQueryResponse response = await _mediator.Send(getAllMenuQueryRequest);
            return Ok(response);

        }
        [HttpPost]
        public async Task<IActionResult> Post(CreateMenuCommandRequest createMenuCommandRequest)
        {
            CreateMenuCommandResponse response = await _mediator.Send(createMenuCommandRequest);
            return StatusCode((int)HttpStatusCode.Created);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] RemoveMenuCommandRequest removeMenuCommandRequest)
        {
            RemoveMenuCommandResponse response=await _mediator.Send(removeMenuCommandRequest);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateMenuCommandRequest updateMenuCommandRequest)
        {
            UpdateMenuCommandResponse response=await _mediator.Send(updateMenuCommandRequest);
            return Ok(response);
        }
    }
}
