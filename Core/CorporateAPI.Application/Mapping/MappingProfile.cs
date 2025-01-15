using AutoMapper;
using CorporateAPI.Application.DTOs.Banner;
using CorporateAPI.Application.DTOs.Home;
using CorporateAPI.Application.DTOs.Lang;
using CorporateAPI.Application.DTOs.Menu;
using CorporateAPI.Application.DTOs.Module;
using CorporateAPI.Application.DTOs.Page;
using CorporateAPI.Application.Features.Commands.Banner.CreateBanner;
using CorporateAPI.Application.Features.Commands.Menu.CreateMenu;
using CorporateAPI.Application.Features.Commands.Page.CreatePage;
using CorporateAPI.Domain.Entities;
using CorporateAPI.Domain.Entities.Banner;
using CorporateAPI.Domain.Entities.Home;
using CorporateAPI.Domain.Entities.Menu;
using CorporateAPI.Domain.Entities.Module;

namespace CorporateAPI.Application.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Menu,CreateMenuCommandRequest>().ReverseMap();
            CreateMap<Menu,ResultMenuDTO>().ReverseMap();
            CreateMap<Menu,UpdateMenuDTO>().ReverseMap();
            CreateMap<MenuTranslation,MenuTranslationDTO>().ReverseMap();

            CreateMap<Page,CreatePageCommandRequest>().ReverseMap();
            CreateMap<Page,ResultPageDTO>().ReverseMap(); 
            CreateMap<Page,UpdatePageDTO>().ReverseMap();
            CreateMap<PageTranslation, PageTranslationDTO>().ReverseMap();

            CreateMap<Home,ResultHomeDTO>().ReverseMap();
            CreateMap<Home,UpdateHomeDTO>().ReverseMap();
            CreateMap<HomeTranslation,HomeTranslationDTO>().ReverseMap();

            CreateMap<Banner, CreateBannerCommandRequest>().ReverseMap();
            CreateMap<Banner, ResultBannerDTO>().ReverseMap();
            CreateMap<Banner, UpdateBannerDTO>().ReverseMap();
            CreateMap<BannerTranslation, BannerTranslationDTO>().ReverseMap();

            CreateMap<Module,ResultModuleDTO>().ReverseMap();
            CreateMap<Module,GetByIdModuleDTO>().ReverseMap();
            CreateMap<Module,CreateModuleDTO>().ReverseMap(); 
            CreateMap<Module,UpdateModuleDTO>().ReverseMap(); 
            CreateMap<ModuleTranslation,ModuleTranslationDTO>().ReverseMap();

            CreateMap<Lang,ResultLangDTO>().ReverseMap();
            CreateMap<Lang,CreateLangDTO>().ReverseMap();
            CreateMap<Lang,UpdateLangDTO>().ReverseMap();


        }
    }
}
