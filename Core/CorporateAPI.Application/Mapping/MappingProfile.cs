using AutoMapper;
using CorporateAPI.Application.DTOs.Lang;
using CorporateAPI.Application.DTOs.Module;
using CorporateAPI.Application.DTOs.Page;
using CorporateAPI.Application.DTOs.PageModule;
using CorporateAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Page,CreatePageDTO>().ReverseMap(); 
            CreateMap<Page,GetPageDTO>().ReverseMap();
            CreateMap<PageTranslation, PageTranslationDTO>().ReverseMap();

            CreateMap<Module, GetModuleDTO>().ReverseMap();
            CreateMap<ModuleTranslation,ModuleTranslationDTO>().ReverseMap();
            CreateMap<Module,UpdateModuleDTO>().ReverseMap(); 

            CreateMap<Module,CreateModuleDTO>().ReverseMap(); 
            CreateMap<ModuleTranslation,CreateModuleTranslationDTO>().ReverseMap();

            CreateMap<Lang,GetLangDTO>().ReverseMap();
            CreateMap<Lang,CreateLangDTO>().ReverseMap();

            CreateMap<Lang,UpdateLangDTO>().ReverseMap();

        }
    }
}
