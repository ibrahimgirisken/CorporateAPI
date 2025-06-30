using CorporateAPI.Application.Features.Queries.TranslationKey.GetAllTranslationKey;
using CorporateAPI.Application.Features.Queries.TranslationKey.GetByIdTranslationKey;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> GetByIdTranslation([FromQuery] GetByIdTranslationKeyRequest getByIdTranslationKeyRequest)
        {
            GetByIdTranslationKeyResponse response = await _mediator.Send(getByIdTranslationKeyRequest);
            return Ok(response.TranslationDTO);
        }
}
