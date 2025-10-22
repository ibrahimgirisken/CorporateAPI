using CorporateAPI.Application.Consts;
using CorporateAPI.Application.CustomAttributes;
using CorporateAPI.Application.Enums;
using CorporateAPI.Application.Features.Commands.Category.CreateCategory;
using CorporateAPI.Application.Features.Commands.Category.RemoveCategory;
using CorporateAPI.Application.Features.Commands.Category.UpdateCategory;
using CorporateAPI.Application.Features.Queries.Category.GetAllCategory;
using CorporateAPI.Application.Features.Queries.Category.GetByIdCategory;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
        [HttpGet("all")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Categories, ActionType = ActionType.Reading, Definition = "Get All Category")]
        public async Task<IActionResult> GetAllCategory([FromQuery] GetAllCategoryQueryRequest getAllCategoryQueryRequest)
        {
            GetAllCategoryQueryResponse response=await _mediator.Send(getAllCategoryQueryRequest);
            return Ok(response.CategoriesDto);
        }

        [HttpGet("by-id")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Categories, ActionType = ActionType.Reading, Definition = "Get By Id Category")]
        public async Task<IActionResult> GetByIdCategory([FromQuery] GetByIdCategoryQueryRequest getByIdCategoryQueryRequest)
        {
            GetByIdCategoryQueryResponse response=await _mediator.Send(getByIdCategoryQueryRequest);
            return Ok(response.CategoryDTO);
        }

        [HttpPost("add")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Categories, ActionType = ActionType.Writing, Definition = "Create Category")]
        public async Task<IActionResult> Post(CreateCategoryCommandRequest createCategoryCommandRequest)
        {
            CreateCategoryCommandResponse response =await _mediator.Send(createCategoryCommandRequest);
            return Ok(response);
        }

        [HttpPut("update")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Categories, ActionType = ActionType.Updating, Definition = "Update Category")]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommandRequest updateCategoryCommandRequest)
        {
            UpdateCategoryCommandResponse response=await _mediator.Send(updateCategoryCommandRequest);
            return Ok(response);
        }

        [HttpDelete("delete")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Categories, ActionType = ActionType.Deleting, Definition = "Remove Category")]

        public async Task<IActionResult> RemoveCategory([FromQuery] RemoveCategoryCommandRequest removeCategoryCommandRequest)
        {
            RemoveCategoryCommandResponse remove=await _mediator.Send(removeCategoryCommandRequest);
            return Ok(remove);
        }
    }
}
