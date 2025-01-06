using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.WebUI.DTOs.Module
{
    public class ModuleTranslationDTO
    {
        public string Name { get; set; }
        public string ModuleData { get; set; }
        public string Locale { get; set; }
        public int ModuleId { get; set; }
    }
}
