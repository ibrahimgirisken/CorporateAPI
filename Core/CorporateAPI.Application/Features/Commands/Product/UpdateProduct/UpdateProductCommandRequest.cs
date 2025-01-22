using CorporateAPI.Application.DTOs.Product;
using MediatR;

namespace CorporateAPI.Application.Features.Commands.Product.UpdateProduct
{
    public class UpdateProductCommandRequest:IRequest<UpdateProductCommandResponse>
    {
        public UpdateProductCommandRequest()
        {
            ProductTranslations = new List<ProductTranslationDTO>();
        }
        public int Id { get; set; }
        public string? Code { get; set; }
        public int? BrandId { get; set; }
        public int? CategoryId { get; set; }
        public string? Image1 { get; set; }
        public string? Image2 { get; set; }
        public string? Image3 { get; set; }
        public string? Image4 { get; set; }
        public string? Image5 { get; set; }
        public int Order { get; set; }
        public bool Status { get; set; } = false;
        public List<ProductTranslationDTO> ProductTranslations { get; set; }
    }
}
