using CorporateAPI.Application.Consts;
using CorporateAPI.Application.CustomAttributes;
using CorporateAPI.Application.Enums;
using CorporateAPI.Application.Features.Commands.Brand.CreateBrand;
using CorporateAPI.Application.Features.Commands.Brand.RemoveBrand;
using CorporateAPI.Application.Features.Commands.Brand.UpdateBrand;
using CorporateAPI.Application.Features.Queries.Brand.GetAllBrand;
using CorporateAPI.Application.Features.Queries.Brand.GetByIdBrand;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreporateAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        readonly IMediator _mediator;

        public BrandsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Brands, ActionType = ActionType.Reading, Definition = "Get All Brand")]
        public async Task<IActionResult> GetAllBrand([FromQuery]GetAllBrandQueryRequest getAllBrandQueryRequest)
        {
            GetAllBrandQueryResponse response=await _mediator.Send(getAllBrandQueryRequest);
            return Ok(response.Brands);
        }
        [HttpGet("by-id")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Brands, ActionType = ActionType.Reading, Definition = "Get By Id Brand")]
        public async Task<IActionResult> GetByIdBrand([FromQuery] GetByIdBrandQueryRequest getByIdBrandQueryRequest)
        {
            GetByIdBrandQueryResponse response=await _mediator.Send(getByIdBrandQueryRequest);
            return Ok(response.Brand);
        }

        [HttpPost("add")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Brands, ActionType = ActionType.Writing, Definition = "Create Brand")]
        public async Task<IActionResult> CreateBrand(CreateBrandCommandRequest createBrandCommandRequest)
        {
            CreateBrandCommandResponse response=await _mediator.Send(createBrandCommandRequest);
            return Ok(response);
        }

        [HttpPut("update")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Brands, ActionType = ActionType.Updating, Definition = "Update Brand")]
        public async Task<IActionResult> UpdateBrand(UpdateBrandCommandRequest updateBrandCommandRequest)
        {
            UpdateBrandCommandResponse response=await _mediator.Send(updateBrandCommandRequest);
            return Ok(response);
        }

        [HttpDelete("delete")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Brands, ActionType = ActionType.Deleting, Definition = "Remove Brand")]
        public async Task<IActionResult> RemoveBrand([FromQuery] RemoveBrandCommandRequest removeBrandCommandRequest)
        {
            RemoveBrandCommandResponse response=await _mediator.Send(removeBrandCommandRequest);
            return Ok(response);
        }
    }
}
