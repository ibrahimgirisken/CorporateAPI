using CoreporateAPI.Persistence.Contexts;
using CorporateAPI.Application.Repositories.Datasheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreporateAPI.Persistence.Repositories.Datasheet
{
    public class DatasheetReadRepository : ReadRepository<CorporateAPI.Domain.Entities.Datasheet.Datasheet>, IDatasheetReadRepository
    {
        public DatasheetReadRepository(CorporateAPIDbContext context) : base(context)
        {
        }
    }
}
