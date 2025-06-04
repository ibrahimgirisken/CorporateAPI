using CoreporateAPI.Persistence.Contexts;
using CorporateAPI.Application.Repositories.Product;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreporateAPI.Persistence.Repositories.Product
{
    public class ProductReadRepository : ReadRepository<CorporateAPI.Domain.Entities.Product.Product>, IProductReadRepository
    {
        public ProductReadRepository(CorporateAPIDbContext context) : base(context)
        {
           
        }

        public async Task<CorporateAPI.Domain.Entities.Product.Product> GetProductByUrlAndLanguageAsync(string url, string langCode)
        {
            return await Table
           .Where(p => !p.IsDeleted)
           .Include(p => p.ProductTranslations)
               .ThenInclude(t => t.Lang)
           .FirstOrDefaultAsync(p =>
               p.ProductTranslations.Any(t => t.Url == url && t.Lang.LangCode == langCode));
        }
    }
}
