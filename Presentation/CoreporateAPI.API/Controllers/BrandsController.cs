using CorporateAPI.Application.Features.Commands.Brand.CreateBrand;
using CorporateAPI.Application.Features.Commands.Brand.RemoveBrand;
using CorporateAPI.Application.Features.Commands.Brand.UpdateBrand;
using CorporateAPI.Application.Features.Queries.Banner.GetAllBanner;
using CorporateAPI.Application.Features.Queries.Brand.GetAllBrand;
using CorporateAPI.Application.Features.Queries.Brand.GetByIdBrand;
using MediatR;
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

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]GetAllBrandQueryRequest getAllBrandQueryRequest)
        {
            var includeAllLanguages = Request.Query["IncludeAllLanguages"].ToString();
            bool includeAllLanguagesFlag = includeAllLanguages.Equals("true", StringComparison.OrdinalIgnoreCase);
            if (string.IsNullOrEmpty(getAllBrandQueryRequest.Language))
            {
                getAllBrandQueryRequest.Language = "en"; // Varsayılan dil
            }
            getAllBrandQueryRequest.IncludeAllLanguages = includeAllLanguagesFlag;
            GetAllBrandQueryResponse response=await _mediator.Send(getAllBrandQueryRequest);
            return Ok(response.Brands);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get([FromRoute] GetByIdBrandQueryRequest getByIdBrandQueryRequest)
        {
            GetByIdBrandQueryResponse response=await _mediator.Send(getByIdBrandQueryRequest);
            return Ok(response.Brand);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateBrandCommandRequest createBrandCommandRequest)
        {
            CreateBrandCommandResponse response=await _mediator.Send(createBrandCommandRequest);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateBrandCommandRequest updateBrandCommandRequest)
        {
            UpdateBrandCommandResponse response=await _mediator.Send(updateBrandCommandRequest);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] RemoveBrandCommandRequest removeBrandCommandRequest)
        {
            RemoveBrandCommandResponse response=await _mediator.Send(removeBrandCommandRequest);
            return Ok(response);
        }
    }
}
