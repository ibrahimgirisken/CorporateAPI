using CorporateAPI.WebUI.DTOs.Banner;
using CorporateAPI.WebUI.DTOs.Lang;
using CorporateAPI.WebUI.DTOs.Product;

namespace CorporateAPI.WebUI.ViewModels.Product
{
    public class CreateProductViewModel
    {
        public CreateProductDTO CreateProductDTO { get; set; }
        public List<ResultLangDTO> GetLangDTOs { get; set; }
    }
}
