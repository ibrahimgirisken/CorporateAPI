using AutoMapper;
using CorporateAPI.Application.DTOs.Module;
using CorporateAPI.Application.DTOs.Page;
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
            CreateMap<Page,ResultPageDTO>().ReverseMap();
            CreateMap<PageModule, ResultModuleDTO>().ReverseMap();
        }
    }
}
