using CorporateAPI.WebUI.DTOs.Banner;
using CorporateAPI.WebUI.DTOs.Lang;

namespace CorporateAPI.WebUI.ViewModels
{
    public class CreateBannerViewModel
    {
        public CreateBannerDTO CreateBannerDTO { get; set; }
        public List<ResultLangDTO> Langs { get; set; }
        public List<BannerTranslationDTO> BannerTranslations { get; set; }
    }
}
