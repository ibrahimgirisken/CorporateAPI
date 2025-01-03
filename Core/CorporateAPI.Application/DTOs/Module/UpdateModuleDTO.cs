using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.DTOs.Module
{
    public class UpdateModuleDTO
    {
        public UpdateModuleDTO()
        {
            ModuleTranslations = new HashSet<CreateModuleTranslationDTO>();
        }
        public ICollection<CreateModuleTranslationDTO> ModuleTranslations { get; set; }
    }
}
