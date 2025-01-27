using System.ComponentModel.DataAnnotations.Schema;

namespace CorporateAPI.WebUI.DTOs.Product
{
    public class UpdateProductDTO
    {
        public UpdateProductDTO()
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
        public string? Video { get; set; }
        [NotMapped]
        public IFormFile? Image1File { get; set; }
        [NotMapped]
        public IFormFile? Image2File { get; set; }
        [NotMapped] 
        public IFormFile? Image3File { get; set; }
        [NotMapped]
        public IFormFile? Image4File { get; set; }
        [NotMapped] 
        public IFormFile? Image5File { get; set; }
        [NotMapped]
        public IFormFile? VideoFile { get; set; }
        public int Order { get; set; }
        public bool Status { get; set; } = false;
        public List<ProductTranslationDTO> ProductTranslations { get; set; }
    }
}
