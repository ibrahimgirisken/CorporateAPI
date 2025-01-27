using CorporateAPI.Domain.Entities.Category;
using System.ComponentModel.DataAnnotations.Schema;

namespace CorporateAPI.WebUI.DTOs.Category
{
    public class CreateCategoryDTO
    {
        public CreateCategoryDTO()
        {
            Children = new List<ResultCategoryDTO>();
            CategoryTranslations = new List<CategoryTranslationDTO>();
        }
        public int? ParentId { get; set; }
        public string? Image1 { get; set; }
        [NotMapped]
        public IFormFile? Image1File { get; set; }
        public int Order { get; set; }
        public bool Status { get; set; } = false;
        public List<ResultCategoryDTO> Children { get; set; }
        public List<CategoryTranslationDTO> CategoryTranslations { get; set; }
    }
}
