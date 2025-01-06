using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.WebUI.DTOs.Module
{
    public class GetByIdModuleDTO
    {
        public int Id { get; set; }
        public ICollection<ModuleTranslationDTO> ModuleTranslations { get; set; }
    }
}
