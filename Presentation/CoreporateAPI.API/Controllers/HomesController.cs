using AutoMapper;
using CorporateAPI.Application.Features.Queries.Home.GetAllHome;
using CorporateAPI.Application.Features.Queries.Home.GetByIdHome;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreporateAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomesController : ControllerBase
    {
        readonly IMediator _mediator;

        public HomesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllHomeQueryRequest getAllHomeQueryRequest)
        {
            GetAllHomeQueryResponse response=await _mediator.Send(getAllHomeQueryRequest);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get([FromRoute] GetByIdHomeQueryRequest getByIdHomeQueryRequest)
        {
            GetByIdHomeQueryResponse response=await _mediator.Send(getByIdHomeQueryRequest);
            return Ok(response);
        }


    }
}
