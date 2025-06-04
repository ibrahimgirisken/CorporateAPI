using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Repositories.Product
{
    public interface IProductReadRepository:IReadRepository<Domain.Entities.Product.Product>
    {
        Task<CorporateAPI.Domain.Entities.Product.Product> GetProductByUrlAndLanguageAsync(string url,string langCode);
    }
}
