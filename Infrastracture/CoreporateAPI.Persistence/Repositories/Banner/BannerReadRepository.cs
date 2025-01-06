using CoreporateAPI.Persistence.Contexts;
using CorporateAPI.Application.Repositories.Banner;
using CorporateAPI.Domain.Entities.Banner;


namespace CoreporateAPI.Persistence.Repositories
{
    public class BannerReadRepository : ReadRepository<Banner>, IBannerReadRepository
    {
        public BannerReadRepository(CorporateAPIDbContext context) : base(context)
        {
        }
    }
}
