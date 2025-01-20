using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.DTOs.Module
{
    public class GetByIdModuleDTO
    {
        public int Id { get; set; }
        public List<ModuleTranslationDTO> ModuleTranslations { get; set; }
    }
}
