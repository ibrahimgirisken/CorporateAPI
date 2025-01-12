using CorporateAPI.Domain.Entities.Banner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.WebUI.DTOs.Banner
{
    public class UpdateBannerDTO
    {
        public int Id { get; set; }
        public UpdateBannerDTO()
        {
            BannerTranslations = new HashSet<BannerTranslationDTO>();
        }
        public string DesktopImage { get; set; }
        public string TableteImage { get; set; }
        public string MobileImage { get; set; }
        public int Order { get; set; }
        public ICollection<BannerTranslationDTO> BannerTranslations { get; set; }
    }
}
