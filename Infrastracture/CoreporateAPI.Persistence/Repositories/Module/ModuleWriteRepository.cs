using CoreporateAPI.Persistence.Contexts;
using CorporateAPI.Application.Repositories;
using CorporateAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreporateAPI.Persistence.Repositories
{
    public class ModuleWriteRepository : WriteRepository<Module>, IModuleWriteRepository
    {
        public ModuleWriteRepository(CorporateAPIDbContext context) : base(context)
        {
        }
    }
}
