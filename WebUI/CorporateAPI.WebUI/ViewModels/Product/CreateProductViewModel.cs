using CorporateAPI.WebUI.DTOs.Brand;
using CorporateAPI.WebUI.DTOs.Category;
using CorporateAPI.WebUI.DTOs.Lang;
using CorporateAPI.WebUI.DTOs.Product;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CorporateAPI.WebUI.ViewModels.Product
{
    public class CreateProductViewModel
    {
        public CreateProductDTO CreateProductDTO { get; set; }
        public List<ResultLangDTO> GetLangDTOs { get; set; }
        public SelectList GetCategories{ get; set; }
        public SelectList GetBrands{ get; set; }
    }
}
