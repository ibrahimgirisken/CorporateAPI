using CorporateAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Domain.Entities.Banner
{
    public class Banner: BaseEntity
    {
        public Banner()
        {
            BannerTranslations=new HashSet<BannerTranslation>();
        }
        public string? DesktopImage { get; set; }
        public string? TableteImage { get; set; }
        public string? MobileImage { get; set; }
        public int Order { get; set; }
        public ICollection<BannerTranslation> BannerTranslations { get; set; }
    }
}
