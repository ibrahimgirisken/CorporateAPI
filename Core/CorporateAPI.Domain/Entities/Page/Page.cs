using CorporateAPI.Domain.Entities.Common;


namespace CorporateAPI.Domain.Entities
{
    public class Page:BaseEntity
    {
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public int Order { get; set; }
        public string? ModuleIds { get; set; }
        public ICollection<PageTranslation> PageTranslations { get; set; }
    }
}
