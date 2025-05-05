using CoreporateAPI.Persistence.Contexts;
using CorporateAPI.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreporateAPI.Application
{
    public class LanguageCodeResolverService : ILanguageCodeResolverService
    {
        private readonly CorporateAPIDbContext _context;

        public LanguageCodeResolverService(CorporateAPIDbContext context)
        {
            _context = context;
        }

        public Guid GetLangIdByLangCode(string langCode)
        {
            var lang = _context.Languages.FirstOrDefault(x => x.LangCode == langCode);
            if (lang == null)
                throw new Exception($"Language code '{langCode}' not found.");
            return lang.Id;
        }
    }
}
