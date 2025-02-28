using CorporateAPI.Application.Consts;
using CorporateAPI.Application.CustomAttributes;
using CorporateAPI.Application.Enums;
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
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Banners, ActionType = ActionType.Reading, Definition = "Get All Banner")]
        public async Task<IActionResult> GetAllBanner([FromQuery] GetAllBannerQueryRequest getAllBannerQueryRequest)
        {

            var includeAllLanguages = Request.Query["IncludeAllLanguages"].ToString();
            bool includeAllLanguagesFlag = includeAllLanguages.Equals("true", StringComparison.OrdinalIgnoreCase);
            string language = Request.Headers["Accept-Language".ToString()];
            if (string.IsNullOrEmpty(language))
            {
                language = "en"; // Varsayılan dil
            }
            getAllBannerQueryRequest.Language = language;
            getAllBannerQueryRequest.IncludeAllLanguages = includeAllLanguagesFlag;

            GetAllBannerQueryResponse response =await _mediator.Send(getAllBannerQueryRequest);
            return Ok(response.Banners);
        }

        [HttpGet("{Id}")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Banners, ActionType = ActionType.Reading, Definition = "Get By Id Banner")]
        public async Task<IActionResult> GetByIdBanner([FromRoute] GetByIdBannerQueryRequest getByIdBannerQueryRequest)
        {
            GetByIdBannerQueryResponse response = await _mediator.Send(getByIdBannerQueryRequest);
            return Ok(response.Banner);
        }

        [HttpPost]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Banners, ActionType = ActionType.Writing, Definition = "Create Banner")]
        public async Task<IActionResult> CreateBanner(CreateBannerCommandRequest createBannerCommandRequest)
        {
            CreateBannerCommandResponse response = await _mediator.Send(createBannerCommandRequest);
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Banners, ActionType = ActionType.Updating, Definition = "Update Banner")]
        public async Task<IActionResult> UpdateBanner(UpdateBannerCommandRequest updateBannerCommandRequest)
        {
            UpdateBannerCommandResponse response = await _mediator.Send(updateBannerCommandRequest);
            return Ok(response);
        }
        [HttpDelete("{Id}")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Banners, ActionType = ActionType.Deleting, Definition = "Remove Banner")]
        public async Task<IActionResult> RemoveBanner([FromRoute] RemoveBannerCommandRequest removeBannerCommandRequest)
        {
            RemoveBannerCommandResponse response = await _mediator.Send(removeBannerCommandRequest);
            return Ok(response);
        }

    }
}
