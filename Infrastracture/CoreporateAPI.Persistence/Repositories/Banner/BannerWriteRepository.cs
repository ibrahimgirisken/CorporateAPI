using CoreporateAPI.Persistence.Contexts;
using CorporateAPI.Application.Repositories.Banner;
using CorporateAPI.Domain.Entities.Banner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreporateAPI.Persistence.Repositories
{
    public class BannerWriteRepository : WriteRepository<Banner>, IBannerWriteRepository
    {
        public BannerWriteRepository(CorporateAPIDbContext context) : base(context)
        {
        }
    }
}
