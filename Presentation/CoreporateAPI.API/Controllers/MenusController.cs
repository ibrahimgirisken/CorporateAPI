using CorporateAPI.Application.Features.Commands.Menu.CreateMenu;
using CorporateAPI.Application.Features.Commands.Menu.RemoveMenu;
using CorporateAPI.Application.Features.Commands.Menu.UpdateMenu;
using CorporateAPI.Application.Features.Queries.Menu.GetAllMenu;
using CorporateAPI.Application.Features.Queries.Menu.GetByIdMenu;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
            string language = Request.Headers["Accept-Language".ToString()];
            if (string.IsNullOrEmpty(language))
            {
                language = "en"; // Varsayılan dil
            }
            getAllMenuQueryRequest.Language = language;
            GetAllMenuQueryResponse response = await _mediator.Send(getAllMenuQueryRequest);
            return Ok(response.menusDto);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get([FromRoute] GetByIdMenuQueryRequest getByIdMenuQueryRequest)
        {
            GetByIdMenuQueryResponse response = await _mediator.Send(getByIdMenuQueryRequest);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateMenuCommandRequest createMenuCommandRequest)
        {
            CreateMenuCommandResponse response = await _mediator.Send(createMenuCommandRequest);
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateMenuCommandRequest updateMenuCommandRequest)
        {
            UpdateMenuCommandResponse response = await _mediator.Send(updateMenuCommandRequest);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] RemoveMenuCommandRequest removeMenuCommandRequest)
        {
            RemoveMenuCommandResponse response = await _mediator.Send(removeMenuCommandRequest);
            return Ok(response);
        }

    }
}
