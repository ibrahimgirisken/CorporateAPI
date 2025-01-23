namespace CorporateAPI.WebUI.DTOs.Category
{
    public class UpdateCategoryDTO
    {
        public int Id { get; set; }
        public UpdateCategoryDTO()
        {
            CategoryTranslations = new List<CategoryTranslationDTO>();
        }
        public int? ParentId { get; set; }
        public string? Image1 { get; set; }
        public int Order { get; set; }
        public bool Status { get; set; } = false;
        public List<CategoryTranslationDTO> CategoryTranslations { get; set; }
    }
}
