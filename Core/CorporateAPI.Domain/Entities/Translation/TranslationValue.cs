using CorporateAPI.Domain.Entities.Common;

namespace CorporateAPI.Domain.Entities.Translation
{
    public class TranslationValue:BaseTranslation
    {
        public Guid TranslationKeyId { get; set; }
        public TranslationKey TranslationKey { get; set; }
        public string Value { get; set; } = null!;
    }
}
