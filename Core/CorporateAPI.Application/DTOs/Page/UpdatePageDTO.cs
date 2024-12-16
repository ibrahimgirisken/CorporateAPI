using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.DTOs.Page
{
    public class UpdatePageDTO
    {
        public int Id { get; set; }
        public UpdatePageDTO()
        {
            PageModuleIds = new HashSet<int?>();
        }
        public int? ParentId { get; set; }
        public ICollection<int?> PageModuleIds { get; set; }
        public ICollection<PageTranslationDTO> Translations { get; set; }
    }
}
