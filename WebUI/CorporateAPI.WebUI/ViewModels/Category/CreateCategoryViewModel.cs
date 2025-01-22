using CorporateAPI.WebUI.DTOs.Banner;
using CorporateAPI.WebUI.DTOs.Category;
using CorporateAPI.WebUI.DTOs.Lang;

namespace CorporateAPI.WebUI.ViewModels.Category
{
    public class CreateCategoryViewModel
    {
        public CreateCategoryDTO CreateCategoryDTO { get; set; }
        public List<ResultLangDTO> GetLangDTOs { get; set; }
    }
}
