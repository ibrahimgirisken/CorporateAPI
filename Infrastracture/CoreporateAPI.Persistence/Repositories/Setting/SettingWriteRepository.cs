using CoreporateAPI.Persistence.Contexts;
using CorporateAPI.Application.Repositories.Setting;

namespace CoreporateAPI.Persistence.Repositories.Setting
{
    public class SettingWriteRepository : WriteRepository<CorporateAPI.Domain.Entities.Setting.Setting>, ISettingWriteRepository
    {
        public SettingWriteRepository(CorporateAPIDbContext context) : base(context)
        {
        }
    }
}
