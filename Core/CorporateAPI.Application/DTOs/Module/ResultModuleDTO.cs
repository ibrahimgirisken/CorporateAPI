using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.DTOs.Module
{
    public class ResultModuleDTO
    {
        public int Id { get; set; }
        public ICollection<ModuleTranslationDTO> ModuleTranslations { get; set; }
    }
}
