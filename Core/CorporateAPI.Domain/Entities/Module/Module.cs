using CorporateAPI.Domain.Entities.Common;

namespace CorporateAPI.Domain.Entities
{
    public class Module:BaseEntity
    {
        public ICollection<ModuleTranslation> ModuleTranslations { get; set; }
    }
}
