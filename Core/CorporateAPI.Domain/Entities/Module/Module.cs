using CorporateAPI.Domain.Entities.Common;

namespace CorporateAPI.Domain.Entities.Module
{
    public class Module:BaseEntity
    {
        public ICollection<ModuleTranslation> ModuleTranslations { get; set; }
    }
}
