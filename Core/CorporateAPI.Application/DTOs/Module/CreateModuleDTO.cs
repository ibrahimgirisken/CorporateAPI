using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.DTOs.Module
{
    public class CreateModuleDTO
    {
        public string ContentType { get; set; }
        public int Order { get; set; }
        public bool Status { get; set; }
        public CreateModuleDTO()
        {
            ModuleTranslations = new List<ModuleTranslationDTO>();
        }
        public List<ModuleTranslationDTO> ModuleTranslations { get; set; }

    }
}
