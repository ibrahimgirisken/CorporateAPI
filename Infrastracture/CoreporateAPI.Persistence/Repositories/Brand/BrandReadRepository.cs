using CoreporateAPI.Persistence.Contexts;
using CorporateAPI.Application.Repositories.Brand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreporateAPI.Persistence.Repositories.Brand
{
    public class BrandReadRepository : ReadRepository<CorporateAPI.Domain.Entities.Brand.Brand>, IBrandReadRepository
    {
        public BrandReadRepository(CorporateAPIDbContext context) : base(context)
        {
        }
    }
}
