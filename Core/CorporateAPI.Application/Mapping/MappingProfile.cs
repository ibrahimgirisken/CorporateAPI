using AutoMapper;
using CorporateAPI.Application.DTOs.Module;
using CorporateAPI.Application.DTOs.Page;
using CorporateAPI.Application.DTOs.PageModule;
using CorporateAPI.Domain.Entities;
using CorporateAPI.Domain.Entities.Relationship;
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
            CreateMap<PageModule,ResultPageModuleDTO>().ReverseMap();

            CreateMap<Module, GetModuleDTO>().ReverseMap();
            CreateMap<ModuleTranslation,ModuleTranslationDTO>().ReverseMap();
            CreateMap<Module,UpdateModuleDTO>().ReverseMap(); 

            CreateMap<Module,CreateModuleDTO>().ReverseMap(); 
            CreateMap<ModuleTranslation,CreateModuleTranslationDTO>().ReverseMap();
        }
    }
}
