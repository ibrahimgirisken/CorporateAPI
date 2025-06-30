using CorporateAPI.Application.Consts;
using CorporateAPI.Application.CustomAttributes;
using CorporateAPI.Application.Enums;
using CorporateAPI.Application.Features.Commands.TranslationKey.CreateTranslationKey;
using CorporateAPI.Application.Features.Commands.TranslationKey.RemoveTranslationKey;
using CorporateAPI.Application.Features.Commands.TranslationKey.UpdateTranslationKey;
using CorporateAPI.Application.Features.Queries.TranslationKey.GetAllTranslationKey;
using CorporateAPI.Application.Features.Queries.TranslationKey.GetByIdTranslationKey;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CoreporateAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TranslationsController : ControllerBase
    {
        readonly IMediator _mediator;

        public TranslationsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("all")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Translations, ActionType = ActionType.Reading, Definition = "Get All Translation")]
        public async Task<IActionResult> GetAllTranslations([FromQuery] GetAllTranslationKeyRequest getAllTranslationsQueryRequest)
        {
            var includeAllLanguages = Request.Query["IncludeAllLanguages"].ToString();
            bool includeAllLanguagesFlag = includeAllLanguages.Equals("true", StringComparison.OrdinalIgnoreCase);
            string language = Request.Headers["Accept-Language".ToString()];
            getAllTranslationsQueryRequest.IncludeAllLanguages = includeAllLanguagesFlag;
            GetAllTranslationKeyResponse response = await _mediator.Send(getAllTranslationsQueryRequest);
            return Ok(response.TranslationDTO);
        }

        [HttpGet("by-id")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Translations, ActionType = ActionType.Reading, Definition = "Get By Id Translation")]
        public async Task<IActionResult> GetByIdTranslation([FromQuery] GetByIdTranslationKeyRequest getByIdTranslationKeyRequest)
        {
            GetByIdTranslationKeyResponse response = await _mediator.Send(getByIdTranslationKeyRequest);
            return Ok(response.TranslationDTO);
        }

        [HttpPost("add")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Translations, ActionType = ActionType.Writing, Definition = "Create Translation")]

        public async Task<IActionResult> CreateTranslate(CreateTranslationKeyRequest createTranslationKeyRequest)
        {
            CreateTranslationKeyResponse response = await _mediator.Send(createTranslationKeyRequest);
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut("update")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Translations, ActionType = ActionType.Updating,
            Definition = "Update Translate")]
        public async Task<IActionResult> UpdateTranslate(UpdateTranslationKeyRequest updateTranslationKeyRequest)
        {
            UpdateTranslationKeyResponse response=await _mediator.Send(updateTranslationKeyRequest);
            return Ok(response);
        }

        [HttpDelete("delete")]
        [AuthorizeDefinition(Menu =AuthorizeDefinitionConstants.Translations,ActionType =ActionType.Deleting,Definition ="Remove Translate")]
        public async Task<IActionResult> RemoveTranslate([FromRoute] RemoveTranslationKeyRequest removeTranslationKeyRequest)
        {
            RemoveTranslationKeyResponse response=await _mediator.Send(removeTranslationKeyRequest);
            return Ok(response);
        }
    }
}
