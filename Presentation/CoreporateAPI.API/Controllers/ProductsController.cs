using CorporateAPI.Application.Consts;
using CorporateAPI.Application.CustomAttributes;
using CorporateAPI.Application.Enums;
using CorporateAPI.Application.Features.Commands.Product.CreateProduct;
using CorporateAPI.Application.Features.Commands.Product.RemoveProduct;
using CorporateAPI.Application.Features.Commands.Product.UpdateProduct;
using CorporateAPI.Application.Features.Queries.Product.GetAllProduct;
using CorporateAPI.Application.Features.Queries.Product.GetByIdProduct;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CoreporateAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        [AuthorizeDefinition(Menu=AuthorizeDefinitionConstants.Products,ActionType =ActionType.Reading,Definition ="Get All Product")]
        public async Task<IActionResult> GetAllProduct([FromQuery] GetAllProductQueryRequest getAllProductQueryRequest)
        {
            var includeAllLanguages = Request.Query["IncludeAllLanguages"].ToString();
            bool includeAllLanguagesFlag = includeAllLanguages.Equals("true", StringComparison.OrdinalIgnoreCase);

            string language = Request.Headers["Accept-Language".ToString()];
            if (string.IsNullOrEmpty(language))
            {
                language = "en"; // Varsayılan dil
            }
            getAllProductQueryRequest.Language = language;
            getAllProductQueryRequest.IncludeAllLanguages = includeAllLanguagesFlag;
            GetAllProductQueryResponse response = await _mediator.Send(getAllProductQueryRequest);
            return Ok(response.ProductsDto);
        }

        [HttpGet("{Id}")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Products, ActionType = ActionType.Reading, Definition = "Get By Id Product")]
        public async Task<IActionResult> GetByIdBanner([FromRoute] GetByIdProductQueryRequest getByIdProductQueryRequest)
        {
            GetByIdProductQueryResponse response=await _mediator.Send(getByIdProductQueryRequest);
            return Ok(response.ProductDTO);
        }

        [HttpPost]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Products, ActionType = ActionType.Writing, Definition = "Create Product")]
        public async Task<IActionResult> CreateProduct(CreateProductCommandRequest createProductCommandRequest)
        {
            CreateProductCommandResponse response=await _mediator.Send(createProductCommandRequest);
            return Ok(response);
        }

        [HttpPut]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Products, ActionType = ActionType.Updating, Definition = "Update Product")]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommandRequest updateProductCommandRequest)
        {
            UpdateProductCommandResponse response=await _mediator.Send(updateProductCommandRequest);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Products, ActionType = ActionType.Deleting, Definition = "Remove Product Item")]
        public async Task<IActionResult> RemoveProductItem([FromQuery] RemoveProductCommandRequest removeProductCommandRequest)
        {
            RemoveProductCommandResponse response=await _mediator.Send(removeProductCommandRequest);
            return Ok(response);
        }

    }
}
