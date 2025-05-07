using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.DTOs.Product
{
    public class ResultProductDTO
    {
        public string Id { get; set; }
        public string? Code { get; set; }
        public Guid? BrandId { get; set; }
        public Guid? CategoryId { get; set; }
        public string? Image1 { get; set; }
        public string? Image2 { get; set; }
        public string? Image3 { get; set; }
        public string? Image4 { get; set; }
        public string? Image5 { get; set; }
        public string? Video { get; set; }
        public int Order { get; set; }
        public bool Status { get; set; } = false;
        public List<ProductTranslationDTO> ProductTranslations { get; set; }
    }
}
