using CoreporateAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


namespace CoreporateAPI.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<CorporateAPIDbContext>
    {
        public CorporateAPIDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder dbContextOptionsBuilder = new();
            // dbContextOptionsBuilder.UseSqlServer(Configuration.ConnectionString);
            dbContextOptionsBuilder.UseNpgsql(Configuration.ConnectionString);
            return new CorporateAPIDbContext(dbContextOptionsBuilder.Options);

        }
    }
}
