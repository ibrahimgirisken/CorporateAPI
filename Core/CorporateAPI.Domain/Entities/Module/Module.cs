using CorporateAPI.Domain.Entities.Common;

namespace CorporateAPI.Domain.Entities.Module
{
    public class Module:BaseEntity
    {
        public string ContentType { get; set; }
        public int Order { get; set; }
        public bool Status { get; set; }
        public List<ModuleTranslation> ModuleTranslations { get; set; }
    }
}
