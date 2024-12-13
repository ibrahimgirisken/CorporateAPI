using CorporateAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Domain.Entities
{
    public class ModuleTranslation:BaseEntity
    {
        public string Name { get; set; }
        public string ModuleData { get; set; }
        public string Locale { get; set; }
        public int ModuleId { get; set; }
        public Module Module { get; set; }
    }
}
