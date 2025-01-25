using CorporateAPI.Application.Features.Commands.Datasheet.CreateDatasheet;
using CorporateAPI.Application.Features.Commands.Datasheet.RemoveDatasheet;
using CorporateAPI.Application.Features.Commands.Datasheet.UpdateDatasheet;
using CorporateAPI.Application.Features.Queries.Datasheet.GetAllDatasheet;
using CorporateAPI.Application.Features.Queries.Datasheet.GetByIdDatasheet;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CoreporateAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatasheetsController : ControllerBase
    {
        readonly IMediator _mediator;

        public DatasheetsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllDatasheetQueryRequest getAllDatasheetQueryRequest)
        {
            GetAllDatasheetQueryResponse response=await _mediator.Send(getAllDatasheetQueryRequest);
            return Ok(response.resultDatasheetsDto);
        }

        [HttpGet("{Id}")]   
        public async Task<IActionResult> Get([FromRoute] GetByIdDatasheetQueryRequest getByIdDatasheetQueryRequest)
        {
            GetByIdDatasheetQueryResponse response=await _mediator.Send(getByIdDatasheetQueryRequest);
            return Ok(response.ResultDatasheetDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateDatasheetCommandRequest createDatasheetCommandRequest)
        {
            CreateDatasheetCommandResponse response=await _mediator.Send(createDatasheetCommandRequest);
            return StatusCode((int) HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateDatasheetCommandRequest updateDatasheetCommandRequest)
        {
            UpdateDatasheetCommandResponse response = await _mediator.Send(updateDatasheetCommandRequest);
             return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] RemoveDatasheetCommandRequest removeDatasheetCommandRequest)
        {
            RemoveDatasheetCommandResponse response=await _mediator.Send(removeDatasheetCommandRequest);
            return Ok(response);
        }
    }
}
