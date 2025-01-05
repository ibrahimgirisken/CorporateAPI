using AutoMapper;
using CorporateAPI.Application.DTOs.Lang;
using CorporateAPI.Application.DTOs.Menu;
using CorporateAPI.Application.DTOs.Module;
using CorporateAPI.Application.DTOs.Page;
using CorporateAPI.Domain.Entities;
using CorporateAPI.Domain.Entities.Menu;
using CorporateAPI.Domain.Entities.Module;

namespace CorporateAPI.Application.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Menu,ResultMenuDTO>().ReverseMap();
            CreateMap<Menu,GetByIdMenuDTO>().ReverseMap();
            CreateMap<Menu,CreateMenuDTO>().ReverseMap();
            CreateMap<Menu,UpdateMenuDTO>().ReverseMap();
            CreateMap<MenuTranslation,MenuTranslationDTO>().ReverseMap();

            CreateMap<Page,ResultPageDTO>().ReverseMap();
            CreateMap<Page,GetByIdPageDTO>().ReverseMap();
            CreateMap<Page,CreatePageDTO>().ReverseMap(); 
            CreateMap<Page,UpdatePageDTO>().ReverseMap();
            CreateMap<PageTranslation, PageTranslationDTO>().ReverseMap();

            CreateMap<Module,ResultModuleDTO>().ReverseMap();
            CreateMap<Module,GetByIdModuleDTO>().ReverseMap();
            CreateMap<Module,CreateModuleDTO>().ReverseMap(); 
            CreateMap<Module,UpdateModuleDTO>().ReverseMap(); 
            CreateMap<ModuleTranslation,ModuleTranslationDTO>().ReverseMap();


            CreateMap<Lang,GetLangDTO>().ReverseMap();
            CreateMap<Lang,CreateLangDTO>().ReverseMap();
            CreateMap<Lang,UpdateLangDTO>().ReverseMap();

        }
    }
}
