using CoreporateAPI.Persistence.Contexts;
using CorporateAPI.Application.Repositories;
using CorporateAPI.Application.Repositories.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreporateAPI.Persistence.Repositories.Product
{
    public class ProductWriteRepository : WriteRepository<CorporateAPI.Domain.Entities.Product.Product>, IProductWriteRepository
    {
        public ProductWriteRepository(CorporateAPIDbContext context) : base(context)
        {
        }
    }
}
