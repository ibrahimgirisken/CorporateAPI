using CorporateAPI.WebUI.DTOs.Banner;
using CorporateAPI.WebUI.DTOs.Lang;

namespace CorporateAPI.WebUI.ViewModels.Banner
{
    public class CreateBannerViewModel
    {
        public CreateBannerDTO CreateBannerDTO { get; set; }
        public List<ResultLangDTO> GetLangDTOs { get; set; }
    }
}
