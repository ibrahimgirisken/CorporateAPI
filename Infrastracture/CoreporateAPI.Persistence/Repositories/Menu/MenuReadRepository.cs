using CoreporateAPI.Persistence.Contexts;
using CorporateAPI.Application.Repositories.Menu;
using CorporateAPI.Domain.Entities.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreporateAPI.Persistence.Repositories
{
    public class MenuReadRepository : ReadRepository<Menu>, IMenuReadRepository
    {
        public MenuReadRepository(CorporateAPIDbContext context) : base(context)
        {
        }
    }
}
