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
        }
        public string Title { get; set; }
        public int? ParentId { get; set; }
        public ICollection<int?> PageModuleIds { get; set; }
        public ICollection<ProductTranslationDTO> Translations { get; set; }
    }
}
