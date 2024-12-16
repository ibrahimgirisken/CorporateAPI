using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.DTOs.Module
{
    public class ModuleDTO
    {
        public ModuleDTO()
        {
            Translsations=new HashSet<ModuleTranslationDTO>();
        }
        public ICollection<ModuleTranslationDTO> Translsations { get; set; }

    }
}
