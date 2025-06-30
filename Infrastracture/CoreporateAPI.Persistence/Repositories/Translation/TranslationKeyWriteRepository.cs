using CoreporateAPI.Persistence.Contexts;
using CorporateAPI.Application.Repositories.TranslationKey;


namespace CoreporateAPI.Persistence.Repositories.Translation
{
    public class TranslationKeyWriteRepository : WriteRepository<CorporateAPI.Domain.Entities.Translation.TranslationKey>, ITranslationKeyWriteRepository
    {
        public TranslationKeyWriteRepository(CorporateAPIDbContext context) : base(context)
        {
        }
    }
}
