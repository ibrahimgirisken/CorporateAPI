using CorporateAPI.Application.Consts;
using CorporateAPI.Application.CustomAttributes;
using CorporateAPI.Application.Enums;
using CorporateAPI.Application.Features.Commands.Product.CreateProduct;
using CorporateAPI.Application.Features.Commands.Product.RemoveProduct;
using CorporateAPI.Application.Features.Commands.Product.UpdateProduct;
using CorporateAPI.Application.Features.Queries.Page.GetByUrlAddressPage;
using CorporateAPI.Application.Features.Queries.Product.GetAllProduct;
using CorporateAPI.Application.Features.Queries.Product.GetByIdProduct;
using CorporateAPI.Application.Features.Queries.Product.GetByUrlProduct;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
        [HttpGet("all")]
        [AuthorizeDefinition(Menu=AuthorizeDefinitionConstants.Products,ActionType =ActionType.Reading,Definition ="Get All Product")]
        public async Task<IActionResult> GetAllProduct([FromQuery] GetAllProductQueryRequest getAllProductQueryRequest)
        {
            var includeAllLanguages = Request.Query["IncludeAllLanguages"].ToString();
            bool includeAllLanguagesFlag = includeAllLanguages.Equals("true", StringComparison.OrdinalIgnoreCase);
            string language = Request.Headers["Accept-Language".ToString()];
            getAllProductQueryRequest.IncludeAllLanguages = includeAllLanguagesFlag;
            GetAllProductQueryResponse response = await _mediator.Send(getAllProductQueryRequest);
            return Ok(response.ProductsDto);
        }

        [HttpGet("by-id")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Products, ActionType = ActionType.Reading, Definition = "Get By Id Product")]
        public async Task<IActionResult> GetByIdProduct([FromQuery] GetByIdProductQueryRequest getByIdProductQueryRequest)
        {
            GetByIdProductQueryResponse response=await _mediator.Send(getByIdProductQueryRequest);
            return Ok(response.ProductDTO);
        }


        [HttpGet("by-url")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Products, ActionType = ActionType.Reading, Definition = "Get By Url Product")]
        public async Task<IActionResult> GetByUrlProduct([FromQuery] GetByUrlProductQueryRequest getByUrlProductQueryRequest)
        {
            GetByUrlProductQueryResponse response = await _mediator.Send(getByUrlProductQueryRequest);
            return Ok(response.ProductDTO);
        }

        [HttpPost("add")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Products, ActionType = ActionType.Writing, Definition = "Create Product")]
        public async Task<IActionResult> CreateProduct(CreateProductCommandRequest createProductCommandRequest)
        {
            CreateProductCommandResponse response=await _mediator.Send(createProductCommandRequest);
            return Ok(response);
        }

        [HttpPut("update")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Products, ActionType = ActionType.Updating, Definition = "Update Product")]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommandRequest updateProductCommandRequest)
        {
            UpdateProductCommandResponse response=await _mediator.Send(updateProductCommandRequest);
            return Ok(response);
        }

        [HttpDelete("delete")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Products, ActionType = ActionType.Deleting, Definition = "Remove Product Item")]
        public async Task<IActionResult> RemoveProduct([FromQuery] RemoveProductCommandRequest removeProductCommandRequest)
        {
            RemoveProductCommandResponse response=await _mediator.Send(removeProductCommandRequest);
            return Ok(response);
        }

    }
}
