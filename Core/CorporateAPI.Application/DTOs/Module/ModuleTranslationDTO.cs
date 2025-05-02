using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.DTOs.Module
{
    public class ModuleTranslationDTO
    {
        public Guid LangId { get; set; }
        public string? Name { get; set; }
        public string? ModuleData { get; set; }
    }
}
