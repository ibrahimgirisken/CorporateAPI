using AutoMapper;
using CorporateAPI.Application.DTOs.Lang;
using CorporateAPI.Application.DTOs.Module;
using CorporateAPI.Application.DTOs.Page;
using CorporateAPI.Domain.Entities;

namespace CorporateAPI.Application.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Page,CreatePageDTO>().ReverseMap(); 
            CreateMap<Page,ResultPageDTO>().ReverseMap();
            CreateMap<PageTranslation, PageTranslationDTO>().ReverseMap();
            CreateMap<Page,GetByIdPageDTO>().ReverseMap();

            CreateMap<Module, ResultModuleDTO>().ReverseMap();
            CreateMap<ModuleTranslation,ModuleTranslationDTO>().ReverseMap();
            CreateMap<Module,UpdateModuleDTO>().ReverseMap(); 

            CreateMap<Module,CreateModuleDTO>().ReverseMap(); 
            CreateMap<ModuleTranslation,ModuleTranslationDTO>().ReverseMap();

            CreateMap<Lang,GetLangDTO>().ReverseMap();
            CreateMap<Lang,CreateLangDTO>().ReverseMap();

            CreateMap<Lang,UpdateLangDTO>().ReverseMap();

        }
    }
}
