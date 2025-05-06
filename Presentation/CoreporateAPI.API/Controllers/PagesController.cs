using CorporateAPI.Application.Consts;
using CorporateAPI.Application.CustomAttributes;
using CorporateAPI.Application.Enums;
using CorporateAPI.Application.Features.Commands.Page.CreatePage;
using CorporateAPI.Application.Features.Commands.Page.RemovePage;
using CorporateAPI.Application.Features.Commands.Page.UpdatePage;
using CorporateAPI.Application.Features.Queries.Page.GetAllPage;
using CorporateAPI.Application.Features.Queries.Page.GetByIdPage;
using CorporateAPI.Application.Features.Queries.Page.GetByUrlAddressPage;
using MediatR;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("all")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Pages, ActionType = ActionType.Reading, Definition = "Get All Page")]
        public async Task<IActionResult> GetAllPage([FromQuery] GetAllPageQueryRequest getAllPageQueryRequest)
        {
            var includeAllLanguages = Request.Query["IncludeAllLanguages"].ToString();
            bool includeAllLanguagesFlag = includeAllLanguages.Equals("true", StringComparison.OrdinalIgnoreCase);
            string language = Request.Headers["Accept-Language".ToString()];
            getAllPageQueryRequest.IncludeAllLanguages = includeAllLanguagesFlag;
            GetAllPageQueryResponse response = await _mediator.Send(getAllPageQueryRequest);
            return Ok(response.PagesDto);
        }
        [HttpGet("by-id")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Pages, ActionType = ActionType.Reading, Definition = "Get By Id Page")]
        public async Task<IActionResult> GetByIdPage([FromQuery] GetByIdPageQueryRequest getByIdPageQueryRequest)
        {
            GetByIdPageQueryResponse response = await _mediator.Send(getByIdPageQueryRequest);
            return Ok(response.PageDto);
        }

        [HttpGet("Page/{UrlAddress}")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Pages, ActionType = ActionType.Reading, Definition = "Get By UrlAddress Page")]
        public async Task<IActionResult> GetByUrlAddressPage([FromRoute] GetByUrlAddressPageQueryRequest getByUrlAddressPageQueryRequest)
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

        [HttpPost("add")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Pages, ActionType = ActionType.Writing, Definition = "Create Page")]
        public async Task<IActionResult> CreatePage(CreatePageCommandRequest createPageCommandRequest)
        {
            CreatePageCommandResponse response=await _mediator.Send(createPageCommandRequest);
            return StatusCode((int)HttpStatusCode.Created);
         }

        [HttpPut("update")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Pages, ActionType = ActionType.Updating, Definition = "Update Page")]
        public async Task<IActionResult> UpdatePage(UpdatePageCommandRequest updatePageCommandRequest)
        {
            UpdatePageCommandResponse response = await _mediator.Send(updatePageCommandRequest);
            return Ok(response);
        }

        [HttpDelete("delete")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Pages, ActionType = ActionType.Deleting, Definition = "Remove Page")]
        public async Task<IActionResult> RemovePage([FromRoute] RemovePageCommandRequest removePageCommandRequest)
        {
            RemovePageCommandResponse response=await _mediator.Send(removePageCommandRequest);
            return Ok(response);
        }

    }
}
