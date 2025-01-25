using CoreporateAPI.Persistence.Contexts;
using CorporateAPI.Application.Repositories;
using CorporateAPI.Domain.Entities;
using CorporateAPI.Domain.Entities.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreporateAPI.Persistence.Repositories
{
    public class PageReadRepository : ReadRepository<Page>, IPageReadRepository
    {
        public PageReadRepository(CorporateAPIDbContext context) : base(context)
        {
        }
    }
}
