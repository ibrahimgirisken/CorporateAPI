using CorporateAPI.Application.Features.Commands.Lang.CreateLang;
using CorporateAPI.Application.Features.Commands.Lang.RemoveLang;
using CorporateAPI.Application.Features.Commands.Lang.UpdateLang;
using CorporateAPI.Application.Features.Queries.Lang.GetAllLang;
using CorporateAPI.Application.Features.Queries.Lang.GetByIdLang;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CoreporateAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LangsController : ControllerBase
    {
        readonly IMediator _mediator;

        public LangsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllLangRequest getAllLangRequest)
        {
            GetAllLangResponse response = await _mediator.Send(getAllLangRequest);
            return Ok(response.LangData);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get([FromRoute] GetByIdLangRequest getByIdLangRequest)
        {
            GetByIdLangResponse response = await _mediator.Send(getByIdLangRequest);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateLangCommandRequest createLangRequest)
        {
            CreateLangResponse response = await _mediator.Send(createLangRequest);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateLangCommandRequest updateLangRequest)
        {
            UpdateLangCommandResponse response = await _mediator.Send(updateLangRequest);
            return Ok(response);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] RemoveLangCommandRequest removeLangRequest)
        {
            RemoveLangCommandResponse response = await _mediator.Send(removeLangRequest);
            return Ok(response);
        }
    }
}
