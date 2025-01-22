using CorporateAPI.Application.DTOs.Product;
using CorporateAPI.Domain.Entities.Product;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Features.Commands.Product.CreateProduct
{
    public class CreateProductCommandRequest:IRequest<CreateProductCommandResponse>
    {
        public CreateProductCommandRequest()
        {
            ProductTranslations = new List<ProductTranslationDTO>();
        }
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
