using CoreporateAPI.Persistence.Contexts;
using CorporateAPI.Application.Repositories.Datasheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreporateAPI.Persistence.Repositories.Datasheet
{
    public class DatasheetWriteRepository : WriteRepository<CorporateAPI.Domain.Entities.Datasheet.Datasheet>, IDatasheetWriteRepository
    {
        public DatasheetWriteRepository(CorporateAPIDbContext context) : base(context)
        {
        }
    }
}
