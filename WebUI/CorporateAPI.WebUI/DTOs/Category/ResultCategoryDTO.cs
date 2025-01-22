namespace CorporateAPI.WebUI.DTOs.Category
{
    public class ResultCategoryDTO
    {
        public int Id { get; set; }
        public ResultCategoryDTO()
        {
            Children = new List<ResultCategoryDTO>();
            CategoryTranslations = new List<CategoryTranslationDTO>();
        }
        public string? Image1 { get; set; }
        public int Order { get; set; }
        public bool Status { get; set; } = false;
        public List<ResultCategoryDTO> Children { get; set; }
        public List<CategoryTranslationDTO> CategoryTranslations { get; set; }
    }
}
