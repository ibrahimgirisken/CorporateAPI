using CorporateAPI.Application.Features.Queries;
using CorporateAPI.Application.Features.Queries.Menu.GetAllMenu;
using CorporateAPI.Application.Repositories;
using CorporateAPI.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            GetAllMenuQueryResponse response=await _mediator.Send(getAllMenuQueryRequest);
            return Ok(response);
            
        }
    }
}
