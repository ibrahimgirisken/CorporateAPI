using CorporateAPI.Domain.Entities.Common;

namespace CorporateAPI.Domain.Entities.Banner
{
    public class Banner: BaseEntity
    {
        public Banner()
        {
            BannerTranslations = new List<BannerTranslation>();
        }
        public string? DesktopImage { get; set; }
        public string? TableteImage { get; set; }
        public string? MobileImage { get; set; }
        public string? DesktopVideo { get; set; }
        public string? MobileVideo { get; set; }
        public int Order { get; set; }
        public bool Status { get; set; }
        public List<BannerTranslation> BannerTranslations { get; set; }
    }
}
