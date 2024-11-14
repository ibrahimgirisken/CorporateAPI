using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreporateAPI.Persistence.Contexts
{
    public class CorporateAPIDbContext : DbContext
    {
        public CorporateAPIDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
