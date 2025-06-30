using CoreporateAPI.Persistence.Contexts;
using CorporateAPI.Application.Repositories.TranslationKey;
using CorporateAPI.Domain.Entities.Translation;

namespace CoreporateAPI.Persistence.Repositories.Translation
{
    public class TranslationKeyReadRepository : ReadRepository<TranslationKey>, ITranslationKeyReadRepository
    {
        public TranslationKeyReadRepository(CorporateAPIDbContext context) : base(context)
        {
        }
    }
}
