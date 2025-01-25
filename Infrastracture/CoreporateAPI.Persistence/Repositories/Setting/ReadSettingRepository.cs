using CoreporateAPI.Persistence.Contexts;
using CorporateAPI.Application.Repositories.Setting;

namespace CoreporateAPI.Persistence.Repositories.Setting
{
    public class ReadSettingRepository : ReadRepository<CorporateAPI.Domain.Entities.Setting.Setting>, ISettingReadRepository
    {
        public ReadSettingRepository(CorporateAPIDbContext context) : base(context)
        {
        }
    }
}
