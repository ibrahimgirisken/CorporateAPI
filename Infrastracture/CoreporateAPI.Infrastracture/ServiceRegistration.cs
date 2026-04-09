using CoreporateAPI.Infrastracture.Services.Token;
using CoreporateAPI.Infrastructure.Services.Configurations;
using CorporateAPI.Application.Abstractions.Services.Configurations;
using CorporateAPI.Application.Abstractions.Token;
using Microsoft.Extensions.DependencyInjection;

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
