using CoreporateAPI.Persistence.Contexts;
using CorporateAPI.Application.Repositories.Brand;
using CorporateAPI.Domain.Entities.Brand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreporateAPI.Persistence.Repositories.Brand
{
    public class BrandWriteRepository : WriteRepository<CorporateAPI.Domain.Entities.Brand.Brand>, IBrandWriteRepository
    {
        public BrandWriteRepository(CorporateAPIDbContext context) : base(context)
        {
        }
    }
}
