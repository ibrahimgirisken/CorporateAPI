using CoreporateAPI.Infrastracture.Services.Token;
using CoreporateAPI.Infrastructure.Services.Configurations;
using CorporateAPI.Application.Abstractions.Token;
using CorporateAPI.Application.Services.Configurations;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreporateAPI.Infrastracture
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenHandler, TokenHandler>();  
            services.AddScoped<IApplicationService,ApplicationService>();
        }
    }
}
