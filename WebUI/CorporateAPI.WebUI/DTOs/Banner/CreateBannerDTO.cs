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
            Translations = new HashSet<BannerTranslationDTO>();
        }
        public string? DesktopImage { get; set; }
        public string? TableteImage { get; set; }
        public string? MobileImage { get; set; }
        public int Order { get; set; } = 1;
        public bool IsDeleted { get; set; }=false;
        public ICollection<BannerTranslationDTO> Translations { get; set; }
    }
}
