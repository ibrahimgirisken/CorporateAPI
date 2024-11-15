using Microsoft.EntityFrameworkCore;
using CoreporateAPI.Persistence.Contexts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorporateAPI.Application.Repositories;
using CoreporateAPI.Persistence.Repositories;

namespace CoreporateAPI.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<CorporateAPIDbContext>(options=>options.UseSqlServer(Configurations.ConnectionString));
            services.AddScoped<IMenuReadRepository, MenuReadRepository>();
            services.AddScoped<IMenuWriteRepository, MenuWriteRepository>();
            services.AddScoped<IPageReadRepository, PageReadRepository>();
            services.AddScoped<IPageWriteRepository, PageWriteRepository>();

        }
    }
}
