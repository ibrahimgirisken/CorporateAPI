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
            Modules = new HashSet<UpdatePageModuleDTO>();
            Translations = new HashSet<PageTranslationDTO>();
        }
        public int? ParentId { get; set; }
        public ICollection<UpdatePageModuleDTO> Modules { get; set; }
        public ICollection<PageTranslationDTO> Translations { get; set; }
    }
}
