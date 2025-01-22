using CorporateAPI.WebUI.DTOs.Banner;
using CorporateAPI.WebUI.DTOs.Brand;
using CorporateAPI.WebUI.DTOs.Lang;

namespace CorporateAPI.WebUI.ViewModels.Brand
{
    public class CreateBrandViewModel
    {
        public CreateBrandDTO CreateBrandDTO { get; set; }
        public List<ResultLangDTO> GetLangDTOs { get; set; }
    }
}
