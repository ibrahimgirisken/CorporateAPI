using CorporateAPI.Domain.Entities.Common;

namespace CorporateAPI.Domain.Entities.Module
{
    public class Module:BaseEntity
    {
        public string ContentType { get; set; }
        public string? Image1 { get; set; }
        public string? Image2 { get; set; }
        public string? Image3 { get; set; }
        public string? Video { get; set; }
        public int Order { get; set; } = 1;
        public bool Status { get; set; }=false; 
        public List<ModuleTranslation> ModuleTranslations { get; set; }
    }
}
