using CoreporateAPI.Persistence.Contexts;
using CorporateAPI.Application.Repositories.Home;
using CorporateAPI.Domain.Entities.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreporateAPI.Persistence.Repositories
{
    public class HomeWriteRepository : WriteRepository<Home>, IHomeWriteRepository
    {
        public HomeWriteRepository(CorporateAPIDbContext context) : base(context)
        {
        }
    }
}
