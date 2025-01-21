using Microsoft.EntityFrameworkCore;
using CoreporateAPI.Persistence.Contexts;
using Microsoft.Extensions.DependencyInjection;
using CorporateAPI.Application.Repositories;
using CoreporateAPI.Persistence.Repositories;
using CorporateAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using CorporateAPI.Application.Repositories.Menu;
using CorporateAPI.Application.Repositories.Banner;
using CorporateAPI.Application.Repositories.Home;
using CorporateAPI.Application.Repositories.Brand;
using CoreporateAPI.Persistence.Repositories.Brand;
using CorporateAPI.Application.Repositories.Product;
using CoreporateAPI.Persistence.Repositories.Product;
using CorporateAPI.Application.Repositories.Category;
using CoreporateAPI.Persistence.Repositories.Category;

namespace CoreporateAPI.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<CorporateAPIDbContext>(options => {
                options.UseSqlServer(Configurations.ConnectionString);
                options.EnableSensitiveDataLogging();
                });
            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                }

            ).AddEntityFrameworkStores<CorporateAPIDbContext>().AddDefaultTokenProviders();
            services.AddScoped<IMenuReadRepository, MenuReadRepository>();
            services.AddScoped<IMenuWriteRepository, MenuWriteRepository>();
            services.AddScoped<IPageReadRepository, PageReadRepository>();
            services.AddScoped<IPageWriteRepository, PageWriteRepository>();
            services.AddScoped<IHomeReadRepository, HomeReadRepository>();
            services.AddScoped<IHomeWriteRepository, HomeWriteRepository>();
            services.AddScoped<IModuleReadRepository, ModuleReadRepository>();
            services.AddScoped<IModuleWriteRepository, ModuleWriteRepository>();
            services.AddScoped<ILangReadRepository, LangReadRepository>();
            services.AddScoped<ILangWriteRepository, LangWriteRepository>();
            services.AddScoped<IBannerReadRepository,BannerReadRepository>();
            services.AddScoped<IBannerWriteRepository, BannerWriteRepository>();
            services.AddScoped<IBrandReadRepository,BrandReadRepository>();
            services.AddScoped<IBrandWriteRepository, BrandWriteRepository>();
            services.AddScoped<IProductReadRepository,ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
            services.AddScoped<ICategoryReadRepository,CategoryReadRepository>();
            services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();

        }
    }
}
