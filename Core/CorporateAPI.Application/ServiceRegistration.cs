using CorporateAPI.Application.Mapping;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CorporateAPI.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection collection)
        {
            collection.AddMediatR(typeof(ServiceRegistration).Assembly);
            collection.AddAutoMapper(typeof(MappingProfile).Assembly);
        }
    }
}
