using CoreporateAPI.Persistence.Contexts;
using CorporateAPI.Application.Repositories.Setting;

namespace CoreporateAPI.Persistence.Repositories.Setting
{
    public class SettingReadRepository : ReadRepository<CorporateAPI.Domain.Entities.Setting.Setting>, ISettingReadRepository
    {
        public SettingReadRepository(CorporateAPIDbContext context) : base(context)
        {
        }
    }
}
