using CoreporateAPI.Persistence.Contexts;
using CorporateAPI.Application.Repositories.Setting;

namespace CoreporateAPI.Persistence.Repositories.Setting
{
    public class WriteSettingRepository : WriteRepository<CorporateAPI.Domain.Entities.Setting.Setting>, ISettingWriteRepository
    {
        public WriteSettingRepository(CorporateAPIDbContext context) : base(context)
        {
        }
    }
}
