namespace CorporateAPI.WebUI.DTOs.Category
{
    public class UpdateCategoryDTO
    {
        public int Id { get; set; }
        public UpdateCategoryDTO()
        {
            Children = new List<ResultCategoryDTO>();
            CategoryTranslations = new List<CategoryTranslationDTO>();
        }
        public int? ParentId { get; set; }
        public string? Image1 { get; set; }
        public int Order { get; set; }
        public bool Status { get; set; } = false;
        public List<ResultCategoryDTO> Children { get; set; }
        public List<CategoryTranslationDTO> CategoryTranslations { get; set; }
    }
}
