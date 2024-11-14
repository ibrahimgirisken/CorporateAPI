using CoreporateAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreporateAPI.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<CorporateAPIDbContext>
    {
        public CorporateAPIDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseSqlServer(Configurations.ConnectionString);
            return new CorporateAPIDbContext(dbContextOptionsBuilder.Options);

        }
    }
}
