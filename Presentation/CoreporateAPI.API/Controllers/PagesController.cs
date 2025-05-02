using CorporateAPI.Application.Features.Commands.Page.CreatePage;
using CorporateAPI.Application.Features.Commands.Page.RemovePage;
using CorporateAPI.Application.Features.Commands.Page.UpdatePage;
using CorporateAPI.Application.Features.Queries.Banner.GetAllBanner;
using CorporateAPI.Application.Features.Queries.Page.GetAllPage;
using CorporateAPI.Application.Features.Queries.Page.GetByIdPage;
using CorporateAPI.Application.Features.Queries.Page.GetByUrlAddressPage;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Net;

namespace CoreporateAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes="Admin")]
    public class PagesController : ControllerBase
    {
        readonly IMediator _mediator;

        public PagesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllPageQueryRequest getAllPageQueryRequest)
        {
            var includeAllLanguages = Request.Query["IncludeAllLanguages"].ToString();
            bool includeAllLanguagesFlag = includeAllLanguages.Equals("true", StringComparison.OrdinalIgnoreCase);
            string language = Request.Headers["Accept-Language".ToString()];
            if (string.IsNullOrEmpty(getAllPageQueryRequest.Language))
            {
                getAllPageQueryRequest.Language = "en"; // Varsayılan dil
            }
            getAllPageQueryRequest.IncludeAllLanguages = includeAllLanguagesFlag;
            GetAllPageQueryResponse response = await _mediator.Send(getAllPageQueryRequest);
            return Ok(response.PagesDto);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> Get([FromRoute] GetByIdPageQueryRequest getByIdPageQueryRequest)
        {
            GetByIdPageQueryResponse response = await _mediator.Send(getByIdPageQueryRequest);
            return Ok(response.PageDto);
        }

        [HttpGet("Page/{UrlAddress}")]
        public async Task<IActionResult> Get([FromRoute] GetByUrlAddressPageQueryRequest getByUrlAddressPageQueryRequest)
        {
            string language = Request.Headers["Accept-Language".ToString()];
            if (string.IsNullOrEmpty(language))
            {
                language = "en"; // Varsayılan dil
            }
            getByUrlAddressPageQueryRequest.Language = language;
            GetByUrlAddressPageQueryResponse response = await _mediator.Send(getByUrlAddressPageQueryRequest);
            return Ok(response.pageDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreatePageCommandRequest createPageCommandRequest)
        {
            CreatePageCommandResponse response=await _mediator.Send(createPageCommandRequest);
            return StatusCode((int)HttpStatusCode.Created);
         }

        [HttpPut]
        public async Task<IActionResult> Update(UpdatePageCommandRequest updatePageCommandRequest)
        {
            UpdatePageCommandResponse response = await _mediator.Send(updatePageCommandRequest);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] RemovePageCommandRequest removePageCommandRequest)
        {
            RemovePageCommandResponse response=await _mediator.Send(removePageCommandRequest);
            return Ok(response);
        }

    }
}
