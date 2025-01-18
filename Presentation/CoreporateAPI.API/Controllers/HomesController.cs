using Azure.Core;
using CorporateAPI.Application.Features.Commands.Home.CreateHome;
using CorporateAPI.Application.Features.Commands.Home.RemoveHome;
using CorporateAPI.Application.Features.Commands.Home.UpdateHome;
using CorporateAPI.Application.Features.Queries.Home.GetAllHome;
using CorporateAPI.Application.Features.Queries.Home.GetByContentTypeHome;
using CorporateAPI.Application.Features.Queries.Home.GetByIdHome;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
        [HttpGet("Home/{ContentType}")]
        public async Task<IActionResult> Get([FromRoute] GetByContentTypeHomeQueryRequest getByContentTypeHomeQueryRequest)
        {
            string language = Request.Headers["Accept-Language".ToString()];
            if (string.IsNullOrEmpty(language))
            {
                language = "en"; // Varsayılan dil
            }
            getByContentTypeHomeQueryRequest.Language = language;
            GetByContentTypeHomeQueryResponse response = await _mediator.Send(getByContentTypeHomeQueryRequest);
            return Ok(response.homeDTO);
        }
        [HttpPost]
        public async Task<IActionResult> Post(CreateHomeCommandRequest createHomeCommandRequest)
        {
          CreateHomeCommandResponse response= await _mediator.Send(createHomeCommandRequest);
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateHomeCommandRequest updateHomeCommandRequest)
        {
          UpdateHomeCommandResponse response= await _mediator.Send(updateHomeCommandRequest);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute]RemoveHomeCommandRequest removeHomeCommandRequest)
        {
           RemoveHomeCommandResponse response= await _mediator.Send(removeHomeCommandRequest);
            return Ok(response);
        }

    }
}
