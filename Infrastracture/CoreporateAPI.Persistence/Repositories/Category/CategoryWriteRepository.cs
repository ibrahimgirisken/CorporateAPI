using CoreporateAPI.Persistence.Contexts;
using CorporateAPI.Application.Repositories.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreporateAPI.Persistence.Repositories.Category
{
    public class CategoryWriteRepository : WriteRepository<CorporateAPI.Domain.Entities.Category.Category>, ICategoryWriteRepository
    {
        public CategoryWriteRepository(CorporateAPIDbContext context) : base(context)
        {
        }
    }
}
