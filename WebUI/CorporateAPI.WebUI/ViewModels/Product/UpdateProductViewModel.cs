using CorporateAPI.WebUI.DTOs.Brand;
using CorporateAPI.WebUI.DTOs.Category;
using CorporateAPI.WebUI.DTOs.Lang;
using CorporateAPI.WebUI.DTOs.Product;

namespace CorporateAPI.WebUI.ViewModels.Product
{
    public class UpdateProductViewModel
    {
        public UpdateProductDTO UpdateProductDTO { get; set; }
        public List<ResultLangDTO> GetLangDTOs { get; set; }
        public List<ResultCategoryDTO> GetCategories { get; set; }
        public List<ResultBrandDTO> GetBrands { get; set; }
    }
}
