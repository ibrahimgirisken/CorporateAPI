
namespace CorporateAPI.Application.DTOs.Product
{
    public class UpdateProductDTO
    {
        public UpdateProductDTO()
        {
            ProductTranslations = new List<ProductTranslationDTO>();
        }
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? Brand { get; set; }
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
