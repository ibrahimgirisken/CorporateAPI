using CorporateAPI.WebUI.DTOs.Category;
using CorporateAPI.WebUI.DTOs.Lang;

namespace CorporateAPI.WebUI.ViewModels.Category
{
    public class UpdateCategoryViewModel
    {
        public UpdateCategoryDTO UpdateCategoryDTO { get; set; }
        public List<ResultLangDTO> GetLangDTOs { get; set; }
    }
}
