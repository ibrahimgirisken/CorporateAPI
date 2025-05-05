using AutoMapper;
using CorporateAPI.Application.Abstractions.Services;

namespace CorporateAPI.Application.Resolvers
{
    public class GenericLangCodeToLangIdResolver<TSource> : IValueResolver<TSource, object, Guid>
    {
        private readonly ILanguageCodeResolverService _langService;

        public GenericLangCodeToLangIdResolver(ILanguageCodeResolverService langService)
        {
            _langService = langService;
        }

        public Guid Resolve(TSource source, object destination, Guid destMember, ResolutionContext context)
        {
            var prop = typeof(TSource).GetProperty("LangCode");
            if (prop == null)
                throw new InvalidOperationException($"'{typeof(TSource).Name}' does not contain a 'LangCode' property.");

            var langCode = prop.GetValue(source)?.ToString();

            if (string.IsNullOrWhiteSpace(langCode))
                throw new ArgumentNullException("LangCode", "LangCode cannot be null or empty.");

            return _langService.GetLangIdByLangCode(langCode);
        }
    }
}
