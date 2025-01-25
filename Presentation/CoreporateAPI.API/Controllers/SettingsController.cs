using CorporateAPI.Application.Features.Commands.Settting.CreateSetting;
using CorporateAPI.Application.Features.Commands.Settting.UpdateSetting;
using CorporateAPI.Application.Features.Queries.Setting.GetByIdSetting;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CoreporateAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : ControllerBase
    {
        readonly IMediator _mediator;

        public SettingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get([FromRoute] GetByIdSettingQueryRequest getByIdSettingQueryRequest)
        {
            GetByIdSettingQueryResponse response = await _mediator.Send(getByIdSettingQueryRequest);
            return Ok(response.ResultSettingDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateSettingCommandRequest createSettingCommandRequest)
        {
            CreateSettingCommandResponse response = await _mediator.Send(createSettingCommandRequest);
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateSettingCommandRequest updateSettingCommandRequest)
        {
            UpdateSettingCommandResponse response = await _mediator.Send(updateSettingCommandRequest);
            return Ok(response);
        }
    }
}
