using AutoMapper;
using CorporateAPI.Application.DTOs.Banner;
using CorporateAPI.Application.DTOs.Brand;
using CorporateAPI.Application.DTOs.Category;
using CorporateAPI.Application.DTOs.Datasheet;
using CorporateAPI.Application.DTOs.Home;
using CorporateAPI.Application.DTOs.Lang;
using CorporateAPI.Application.DTOs.Menu;
using CorporateAPI.Application.DTOs.Module;
using CorporateAPI.Application.DTOs.Page;
using CorporateAPI.Application.DTOs.Product;
using CorporateAPI.Application.Features.Commands.Banner.CreateBanner;
using CorporateAPI.Application.Features.Commands.Banner.UpdateBanner;
using CorporateAPI.Application.Features.Commands.Brand.CreateBrand;
using CorporateAPI.Application.Features.Commands.Brand.UpdateBrand;
using CorporateAPI.Application.Features.Commands.Category.CreateCategory;
using CorporateAPI.Application.Features.Commands.Category.UpdateCategory;
using CorporateAPI.Application.Features.Commands.Datasheet.CreateDatasheet;
using CorporateAPI.Application.Features.Commands.Datasheet.UpdateDatasheet;
using CorporateAPI.Application.Features.Commands.Home.CreateHome;
using CorporateAPI.Application.Features.Commands.Home.UpdateHome;
using CorporateAPI.Application.Features.Commands.Lang.CreateLang;
using CorporateAPI.Application.Features.Commands.Lang.UpdateLang;
using CorporateAPI.Application.Features.Commands.Menu.CreateMenu;
using CorporateAPI.Application.Features.Commands.Menu.UpdateMenu;
using CorporateAPI.Application.Features.Commands.Module.CreateModule;
using CorporateAPI.Application.Features.Commands.Page.CreatePage;
using CorporateAPI.Application.Features.Commands.Page.UpdatePage;
using CorporateAPI.Application.Features.Commands.Product.CreateProduct;
using CorporateAPI.Application.Features.Commands.Product.UpdateProduct;
using CorporateAPI.Domain.Entities;
using CorporateAPI.Domain.Entities.Banner;
using CorporateAPI.Domain.Entities.Brand;
using CorporateAPI.Domain.Entities.Category;
using CorporateAPI.Domain.Entities.Datasheet;
using CorporateAPI.Domain.Entities.Home;
using CorporateAPI.Domain.Entities.Menu;
using CorporateAPI.Domain.Entities.Module;
using CorporateAPI.Domain.Entities.Product;

namespace CorporateAPI.Application.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Menu,ResultMenuDTO>().ReverseMap();
            CreateMap<Menu,CreateMenuCommandRequest>().ReverseMap();
            CreateMap<Menu,UpdateMenuCommandRequest>().ReverseMap();
            CreateMap<MenuTranslation,MenuTranslationDTO>().ReverseMap();

            CreateMap<Category, ResultCategoryDTO>().ReverseMap();
            CreateMap<Category, CreateCategoryCommandRequest>().ReverseMap();
            CreateMap<Category, UpdateCategoryCommandRequest>().ReverseMap();
            CreateMap<CategoryTranslation,CategoryTranslationDTO>().ReverseMap();

            CreateMap<Page,CreatePageCommandRequest>().ReverseMap();
            CreateMap<Page,ResultPageDTO>().ReverseMap(); 
            CreateMap<Page,UpdatePageCommandRequest>().ReverseMap();
            CreateMap<PageTranslation, PageTranslationDTO>().ReverseMap();

            CreateMap<Home,CreateHomeCommandRequest>().ReverseMap();
            CreateMap<Home,ResultHomeDTO>().ReverseMap();
            CreateMap<Home,UpdateHomeCommandRequest>().ReverseMap();
            CreateMap<HomeTranslation,HomeTranslationDTO>().ReverseMap();

            CreateMap<Banner, CreateBannerCommandRequest>().ReverseMap();
            CreateMap<Banner, ResultBannerDTO>().ReverseMap();
            CreateMap<Banner, UpdateBannerCommandRequest>().ReverseMap();
            CreateMap<BannerTranslation, BannerTranslationDTO>().ReverseMap();

            CreateMap<Module,ResultModuleDTO>().ReverseMap();
            CreateMap<Module,CreateModuleCommandRequest>().ReverseMap(); 
            CreateMap<Module,UpdateHomeCommandRequest>().ReverseMap(); 
            CreateMap<ModuleTranslation,ModuleTranslationDTO>().ReverseMap();

            CreateMap<Lang,ResultLangDTO>().ReverseMap();
            CreateMap<Lang,CreateLangCommandRequest>().ReverseMap();
            CreateMap<Lang,UpdateLangCommandRequest>().ReverseMap();

            CreateMap<Product,ResultProductDTO>().ReverseMap();
            CreateMap<Product,CreateProductCommandRequest>().ReverseMap();
            CreateMap<Product,UpdateProductCommandRequest>().ReverseMap();
            CreateMap<ProductTranslation, ProductTranslationDTO>().ReverseMap();

            CreateMap<Brand,ResultBrandDTO>().ReverseMap();
            CreateMap<Brand,CreateBrandCommandRequest>().ReverseMap();
            CreateMap<Brand,UpdateBrandCommandRequest>().ReverseMap();

            CreateMap<Datasheet,CreateDatasheetCommandRequest>().ReverseMap();
            CreateMap<Datasheet,ResultDatasheetDTO>().ReverseMap();
            CreateMap<Datasheet, UpdateDatasheetCommandRequest>().ReverseMap();
            CreateMap<DatasheetTranslation,DatasheetTranslationDTO>().ReverseMap();

        }
    }
}
