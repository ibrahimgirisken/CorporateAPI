using Microsoft.EntityFrameworkCore;
using CoreporateAPI.Persistence.Contexts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreporateAPI.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<CorporateAPIDbContext>(options=>options.UseSqlServer(Configurations.ConnectionString));
        }
    }
}
