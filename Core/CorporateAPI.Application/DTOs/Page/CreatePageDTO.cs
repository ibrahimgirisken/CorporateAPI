using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.DTOs.Page
{
    public class CreatePageDTO
    {
         public CreatePageDTO()
        {
            PageModuleIds = new HashSet<int?>();
            Translations=new HashSet<PageTranslationDTO>();
        }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public int Order { get; set; }
        public int? ParentId { get; set; }
        public ICollection<int?> PageModuleIds { get; set; }
        public ICollection<PageTranslationDTO> Translations { get; set; }
    }
}
