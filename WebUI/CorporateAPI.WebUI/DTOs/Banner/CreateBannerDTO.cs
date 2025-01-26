using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.WebUI.DTOs.Banner
{
    public class CreateBannerDTO
    {
        public CreateBannerDTO()
        {
            BannerTranslations = new List<BannerTranslationDTO>();
        }
        public string? DesktopImage { get; set; }
        public string? TableteImage { get; set; }
        public string? MobileImage { get; set; }
        public int Order { get; set; }
        public bool Status { get; set; }
        public List<BannerTranslationDTO> BannerTranslations { get; set; }
    }
}
