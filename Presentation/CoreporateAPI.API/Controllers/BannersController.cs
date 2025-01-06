using CorporateAPI.Application.Features.Commands.Banner.CreateBanner;
using CorporateAPI.Application.Features.Commands.Banner.RemoveBanner;
using CorporateAPI.Application.Features.Commands.Banner.UpdateBanner;
using CorporateAPI.Application.Features.Queries.Banner.GetAllBanner;
using CorporateAPI.Application.Features.Queries.Banner.GetByIdBanner;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CoreporateAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannersController : ControllerBase
    {
        readonly IMediator _mediator;

        public BannersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllBannerQueryRequest getAllBannerQueryRequest)
        {
            GetAllBannerQueryResponse response =await _mediator.Send(getAllBannerQueryRequest);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get([FromRoute] GetByIdBannerQueryRequest getByIdBannerQueryRequest)
        {
            GetByIdBannerQueryResponse response = await _mediator.Send(getByIdBannerQueryRequest);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateBannerCommandRequest createBannerCommandRequest)
        {
            CreateBannerCommandResponse response = await _mediator.Send(createBannerCommandRequest);
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateBannerCommandRequest updateBannerCommandRequest)
        {
            UpdateBannerCommandResponse response = await _mediator.Send(updateBannerCommandRequest);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] RemoveBannerCommandRequest removeBannerCommandRequest)
        {
            RemoveBannerCommandResponse response = await _mediator.Send(removeBannerCommandRequest);
            return Ok(response);
        }

    }
}
