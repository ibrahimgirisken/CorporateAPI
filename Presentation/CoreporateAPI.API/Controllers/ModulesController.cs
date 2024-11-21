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
        public async Task<IActionResult> Get(GetAllMenuQueryRequest getAllMenuQueryRequest)
        {
            return Ok();
        }
    }
}
