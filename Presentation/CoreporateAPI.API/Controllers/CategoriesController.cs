using CorporateAPI.Application.Features.Commands.Category.CreateCategory;
using CorporateAPI.Application.Features.Commands.Category.RemoveCategory;
using CorporateAPI.Application.Features.Commands.Category.UpdateCategory;
using CorporateAPI.Application.Features.Queries.Category.GetAllCategory;
using CorporateAPI.Application.Features.Queries.Category.GetByIdCategory;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CoreporateAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllCategoryQueryRequest getAllCategoryQueryRequest)
        {
            GetAllCategoryQueryResponse response=await _mediator.Send(getAllCategoryQueryRequest);
            return Ok(response.CategoriesDto);
        }
        
        [HttpGet("{Id}")]
        public async Task<IActionResult> Get([FromRoute] GetByIdCategoryQueryRequest getByIdCategoryQueryRequest)
        {
            GetByIdCategoryQueryResponse response=await _mediator.Send(getByIdCategoryQueryRequest);
            return Ok(response.CategoryDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateCategoryCommandRequest createCategoryCommandRequest)
        {
            CreateCategoryCommandResponse response =await _mediator.Send(createCategoryCommandRequest);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCategoryCommandRequest updateCategoryCommandRequest)
        {
            UpdateCategoryCommandResponse response=await _mediator.Send(updateCategoryCommandRequest);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(RemoveCategoryCommandRequest removeCategoryCommandRequest)
        {
            RemoveCategoryCommandResponse remove=await _mediator.Send(removeCategoryCommandRequest);
            return Ok(remove);
        }
    }
}
