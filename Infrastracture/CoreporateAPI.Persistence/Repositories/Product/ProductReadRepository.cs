using CoreporateAPI.Persistence.Contexts;
using CorporateAPI.Application.Repositories.Product;
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
    }
}
