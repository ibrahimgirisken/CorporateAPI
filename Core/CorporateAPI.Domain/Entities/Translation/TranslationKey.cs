using CorporateAPI.Domain.Entities.Common;

namespace CorporateAPI.Domain.Entities.Translation
{
    public class TranslationKey:BaseEntity
    {
        public TranslationKey()
        {
            Translations = new List<TranslationValue>();
        }
        public string Key { get; set; } = null!;
        public string? Description { get; set; }
        public List<TranslationValue> Translations { get; set; }
    }
}
