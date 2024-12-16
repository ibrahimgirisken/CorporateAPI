using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.DTOs.Page
{
    public class PageDTO
    {
         public PageDTO()
        {
            PageModuleIds = new HashSet<int?>();
            Translations=new HashSet<PageTranslationDTO>();
        }
        public int? ParentId { get; set; }
        public ICollection<int?> PageModuleIds { get; set; }
        public ICollection<PageTranslationDTO> Translations { get; set; }
    }
}
