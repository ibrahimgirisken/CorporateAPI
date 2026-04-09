using CorporateAPI.Domain.Entities.Common;

namespace CorporateAPI.Domain.Entities.Banner
{
    public class BannerTranslation:BaseTranslation
    {
        public string? Url { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public Guid BannerId { get; set; }
        public Domain.Entities.Banner.Banner Banner { get; set; }
    }
}
