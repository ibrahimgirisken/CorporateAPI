using CorporateAPI.WebUI.DTOs.Brand;
using CorporateAPI.WebUI.DTOs.Lang;

namespace CorporateAPI.WebUI.ViewModels.Brand
{
    public class UpdateBrandViewModel
    {
        public UpdateBrandDTO UpdateBrandDTO { get; set; }
        public List<ResultLangDTO> GetLangDTOs { get; set; }
    }
}
