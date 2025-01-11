using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.DTOs.Banner
{
    public class CreateBannerDTO
    {
        public CreateBannerDTO()
        {
            BannerTranslations=new HashSet<BannerTranslationDTO>();
        }
        public string? DesktopImage { get; set; }
        public string? TableteImage { get; set; }
        public string? MobileImage { get; set; }
        public int Order { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<BannerTranslationDTO>? BannerTranslations { get; set; }
    }
}
