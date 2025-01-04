using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.DTOs.Module
{
    public class UpdateModuleDTO
    {
        public int Id { get; set; }
        public UpdateModuleDTO()
        {
            ModuleTranslations = new HashSet<ModuleTranslationDTO>();
        }
        public ICollection<ModuleTranslationDTO> ModuleTranslations { get; set; }
    }
}
