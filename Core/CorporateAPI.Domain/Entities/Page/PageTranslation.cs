using CorporateAPI.Domain.Entities.Common;

namespace CorporateAPI.Domain.Entities
{
    public class PageTranslation:BaseEntity
    {
        public string Locale { get; set; }
        public string? Title { get; set; }
        public string? Url { get; set; }
        public string? PageTitle { get; set; }
        public string? Brief { get; set; }
        public string? MetaDescription { get; set; }
        public string? Content { get; set; }
        public int PageId { get; set; }
        public Page Page { get; set; }
    }
}
