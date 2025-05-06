using AutoMapper;
using CorporateAPI.Application.DTOs.Banner;
using CorporateAPI.Application.DTOs.Brand;
using CorporateAPI.Application.DTOs.Category;
using CorporateAPI.Application.DTOs.Datasheet;
using CorporateAPI.Application.DTOs.Home;
using CorporateAPI.Application.DTOs.Lang;
using CorporateAPI.Application.DTOs.Module;
using CorporateAPI.Application.DTOs.Page;
using CorporateAPI.Application.DTOs.Product;
using CorporateAPI.Application.DTOs.Setting;
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
using CorporateAPI.Application.Features.Commands.Module.CreateModule;
using CorporateAPI.Application.Features.Commands.Module.UpdateModule;
using CorporateAPI.Application.Features.Commands.Page.CreatePage;
using CorporateAPI.Application.Features.Commands.Page.UpdatePage;
using CorporateAPI.Application.Features.Commands.Product.CreateProduct;
using CorporateAPI.Application.Features.Commands.Product.UpdateProduct;
using CorporateAPI.Application.Features.Commands.Settting.CreateSetting;
using CorporateAPI.Application.Features.Commands.Settting.UpdateSetting;
using CorporateAPI.Application.Resolvers;
using CorporateAPI.Domain.Entities;
using CorporateAPI.Domain.Entities.Banner;
using CorporateAPI.Domain.Entities.Brand;
using CorporateAPI.Domain.Entities.Category;
using CorporateAPI.Domain.Entities.Datasheet;
using CorporateAPI.Domain.Entities.Home;
using CorporateAPI.Domain.Entities.Module;
using CorporateAPI.Domain.Entities.Page;
using CorporateAPI.Domain.Entities.Product;
using CorporateAPI.Domain.Entities.Setting;

namespace CorporateAPI.Application.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<SettingTranslationDTO, SettingTranslation>()
                .ForMember(dest => dest.LangId,
                           opt => opt.MapFrom<GenericLangCodeToLangIdResolver<SettingTranslationDTO>>())
                .ForMember(dest => dest.Lang, opt => opt.Ignore());

            CreateMap<SettingTranslation, SettingTranslationDTO>()
                .ForMember(dest => dest.LangCode,
                           opt => opt.MapFrom(src => src.Lang != null ? src.Lang.LangCode : null));


            CreateMap<CategoryTranslationDTO, CategoryTranslation>()
                .ForMember(dest => dest.LangId,
                           opt => opt.MapFrom<GenericLangCodeToLangIdResolver<CategoryTranslationDTO>>())
                .ForMember(dest => dest.Lang, opt => opt.Ignore());

            CreateMap<CategoryTranslation, CategoryTranslationDTO>()
                .ForMember(dest => dest.LangCode,
                           opt => opt.MapFrom(src => src.Lang != null ? src.Lang.LangCode : null));


            CreateMap<PageTranslationDTO, PageTranslation>()
                .ForMember(dest => dest.LangId,
                           opt => opt.MapFrom<GenericLangCodeToLangIdResolver<PageTranslationDTO>>())
                .ForMember(dest => dest.Lang, opt => opt.Ignore());

            CreateMap<PageTranslation, PageTranslationDTO>()
                .ForMember(dest => dest.LangCode,
                           opt => opt.MapFrom(src => src.Lang != null ? src.Lang.LangCode : null));


            CreateMap<HomeTranslationDTO, HomeTranslation>()
                .ForMember(dest => dest.LangId,
                           opt => opt.MapFrom<GenericLangCodeToLangIdResolver<HomeTranslationDTO>>())
                .ForMember(dest => dest.Lang, opt => opt.Ignore());

            CreateMap<HomeTranslation, HomeTranslationDTO>()
                .ForMember(dest => dest.LangCode,
                           opt => opt.MapFrom(src => src.Lang != null ? src.Lang.LangCode : null));


            CreateMap<BannerTranslationDTO, BannerTranslation>()
                .ForMember(dest => dest.LangId,
                           opt => opt.MapFrom<GenericLangCodeToLangIdResolver<BannerTranslationDTO>>())
                .ForMember(dest => dest.Lang, opt => opt.Ignore());

            CreateMap<BannerTranslation, BannerTranslationDTO>()
                .ForMember(dest => dest.LangCode,
                           opt => opt.MapFrom(src => src.Lang != null ? src.Lang.LangCode : null));


            CreateMap<ModuleTranslationDTO, ModuleTranslation>()
                .ForMember(dest => dest.LangId,
                           opt => opt.MapFrom<GenericLangCodeToLangIdResolver<ModuleTranslationDTO>>())
                .ForMember(dest => dest.Lang, opt => opt.Ignore());

            CreateMap<ModuleTranslation, ModuleTranslationDTO>()
                .ForMember(dest => dest.LangCode,
                           opt => opt.MapFrom(src => src.Lang != null ? src.Lang.LangCode : null));


            CreateMap<ProductTranslationDTO, ProductTranslation>()
                .ForMember(dest => dest.LangId,
                           opt => opt.MapFrom<GenericLangCodeToLangIdResolver<ProductTranslationDTO>>())
                .ForMember(dest => dest.Lang, opt => opt.Ignore());

            CreateMap<ProductTranslation, ProductTranslationDTO>()
                .ForMember(dest => dest.LangCode,
                           opt => opt.MapFrom(src => src.Lang != null ? src.Lang.LangCode : null));


            CreateMap<DatasheetTranslationDTO, DatasheetTranslation>()
                .ForMember(dest => dest.LangId,
                           opt => opt.MapFrom<GenericLangCodeToLangIdResolver<DatasheetTranslationDTO>>())
                .ForMember(dest => dest.Lang, opt => opt.Ignore());

            CreateMap<DatasheetTranslation, DatasheetTranslationDTO>()
                .ForMember(dest => dest.LangCode,
                           opt => opt.MapFrom(src => src.Lang != null ? src.Lang.LangCode : null));


            // === Base Entities and DTOs ===

            CreateMap<Setting, ResultSettingDTO>().ReverseMap();
            CreateMap<Setting, CreateSettingCommandRequest>().ReverseMap();
            CreateMap<Setting, UpdateSettingCommandRequest>().ReverseMap();

            CreateMap<Category, ResultCategoryDTO>().ReverseMap();
            CreateMap<Category, CreateCategoryCommandRequest>().ReverseMap();
            CreateMap<Category, UpdateCategoryCommandRequest>().ReverseMap();

            CreateMap<Page, ResultPageDTO>().ReverseMap();
            CreateMap<Page, CreatePageCommandRequest>().ReverseMap();
            CreateMap<Page, UpdatePageCommandRequest>().ReverseMap();

            CreateMap<Home, ResultHomeDTO>().ReverseMap();
            CreateMap<Home, CreateHomeCommandRequest>().ReverseMap();
            CreateMap<Home, UpdateHomeCommandRequest>().ReverseMap();

            CreateMap<Banner, ResultBannerDTO>().ReverseMap();
            CreateMap<Banner, CreateBannerCommandRequest>().ReverseMap();
            CreateMap<Banner, UpdateBannerCommandRequest>().ReverseMap();

            CreateMap<Module, ResultModuleDTO>().ReverseMap();
            CreateMap<Module, CreateModuleCommandRequest>().ReverseMap();
            CreateMap<Module, UpdateModuleCommandRequest>().ReverseMap();

            CreateMap<Lang, ResultLangDTO>().ReverseMap();
            CreateMap<Lang, CreateLangCommandRequest>().ReverseMap();
            CreateMap<Lang, UpdateLangCommandRequest>().ReverseMap();

            CreateMap<Product, ResultProductDTO>().ReverseMap();
            CreateMap<Product, CreateProductCommandRequest>().ReverseMap();
            CreateMap<Product, UpdateProductCommandRequest>().ReverseMap();

            CreateMap<Datasheet, ResultDatasheetDTO>().ReverseMap();
            CreateMap<Datasheet, CreateDatasheetCommandRequest>().ReverseMap();
            CreateMap<Datasheet, UpdateDatasheetCommandRequest>().ReverseMap();

            CreateMap<Brand,ResultBrandDTO>().ReverseMap();
            CreateMap<Brand,CreateBrandCommandRequest>().ReverseMap();
            CreateMap<Brand,UpdateBrandCommandRequest>().ReverseMap();
        }
    }
}
