using CorporateAPI.Domain.Entities;
using CorporateAPI.WebUI.DTOs.Banner;
using CorporateAPI.WebUI.DTOs.Lang;

namespace CorporateAPI.WebUI.ViewModels.Banner
{
    public class UpdateBannerViewModel
    {
        public UpdateBannerDTO UpdateBannerDTO { get; set; }
        public List<ResultLangDTO> GetLangDTOs { get; set; }
    }
}
