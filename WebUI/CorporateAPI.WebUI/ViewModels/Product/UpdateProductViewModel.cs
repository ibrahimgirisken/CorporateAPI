using CorporateAPI.WebUI.DTOs.Banner;
using CorporateAPI.WebUI.DTOs.Lang;
using CorporateAPI.WebUI.DTOs.Product;

namespace CorporateAPI.WebUI.ViewModels.Product
{
    public class UpdateProductViewModel
    {
        public UpdateProductDTO UpdateProductDTO { get; set; }
        public List<ResultLangDTO> GetLangDTOs { get; set; }
    }
}
