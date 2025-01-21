using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.WebUI.DTOs.Module
{
    public class UpdateModuleDTO
    {
        public int Id { get; set; }
        public string ContentType { get; set; }
        public UpdateModuleDTO()
        {
            ModuleTranslations = new List<ModuleTranslationDTO>();
        }
        public List<ModuleTranslationDTO> ModuleTranslations { get; set; }
        public int Order { get; set; }
    }
}
