using AutoMapper;
using CorporateAPI.Application.DTOs.Banner;
using CorporateAPI.Application.DTOs.Home;
using CorporateAPI.Application.DTOs.Lang;
using CorporateAPI.Application.DTOs.Menu;
using CorporateAPI.Application.DTOs.Module;
using CorporateAPI.Application.DTOs.Page;
using CorporateAPI.Application.Features.Commands.Banner.CreateBanner;
using CorporateAPI.Application.Features.Commands.Banner.UpdateBanner;
using CorporateAPI.Application.Features.Commands.Home.CreateHome;
using CorporateAPI.Application.Features.Commands.Home.UpdateHome;
using CorporateAPI.Application.Features.Commands.Lang.CreateLang;
using CorporateAPI.Application.Features.Commands.Lang.UpdateLang;
using CorporateAPI.Application.Features.Commands.Menu.CreateMenu;
using CorporateAPI.Application.Features.Commands.Menu.UpdateMenu;
using CorporateAPI.Application.Features.Commands.Page.CreatePage;
using CorporateAPI.Application.Features.Commands.Page.UpdatePage;
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
            CreateMap<UpdateMenuCommandRequest, Menu>()
            .ForMember(dest => dest.MenuTranslations, opt => opt.Ignore());
            CreateMap<MenuTranslation,MenuTranslationDTO>().ReverseMap();

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
            CreateMap<Module,CreateModuleDTO>().ReverseMap(); 
            CreateMap<Module,UpdateHomeCommandRequest>().ReverseMap(); 
            CreateMap<ModuleTranslation,ModuleTranslationDTO>().ReverseMap();

            CreateMap<Lang,ResultLangDTO>().ReverseMap();
            CreateMap<Lang,CreateLangCommandRequest>().ReverseMap();
            CreateMap<Lang,UpdateLangCommandRequest>().ReverseMap();


        }
    }
}
