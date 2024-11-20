using CoreporateAPI.Persistence.Contexts;
using CorporateAPI.Application.Repositories;
using CorporateAPI.Domain.Entities.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreporateAPI.Persistence.Repositories
{
    public class ModuleReadRepository : ReadRepository<Module>, IModuleReadRepository
    {
        public ModuleReadRepository(CorporateAPIDbContext context) : base(context)
        {
        }
    }
}
