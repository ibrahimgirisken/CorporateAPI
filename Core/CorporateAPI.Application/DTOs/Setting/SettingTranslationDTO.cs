using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorporateAPI.Application.DTOs.Setting
{
    public class SettingTranslationDTO
    {
        public string Locale { get; set; }
        public string? Title { get; set; }
        public string? MetaDescription { get; set; }
    }
}
