using CorporateAPI.Application.DTOs.Module;
using CorporateAPI.Application.DTOs.PageModule;
using CorporateAPI.Domain.Entities.Relationship;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.DTOs.Page
{
    public class GetPageDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<GetPageDTO?> Children { get; set; }
        public ICollection<ResultPageModuleDTO?> Modules { get; set; }
        public ICollection<PageTranslationDTO> Translations { get; set; }

    }
}
