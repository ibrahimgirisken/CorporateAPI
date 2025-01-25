using CorporateAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Domain.Entities.Setting
{
    public class SettingTranslation:BaseTranslation
    {
        public string Title { get; set; }
        public string MetaDescription { get; set; }
        public int SettingId { get; set; }
        public Setting Setting { get; set; }
    }
}
