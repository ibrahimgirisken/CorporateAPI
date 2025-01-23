namespace CorporateAPI.WebUI.DTOs.Product
{
    public class CreateProductDTO
    {
        public CreateProductDTO()
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
