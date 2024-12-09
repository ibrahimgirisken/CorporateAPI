using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.DTOs.Module
{
    public class CreateModuleDTO
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string ModuleData { get; set; }
        public string Config { get; set; }
    }
}
