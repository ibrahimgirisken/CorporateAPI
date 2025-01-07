using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CorporateAPI.WebUI.DTOs.Banner
{
    public class BannerTranslationDTO
    {
        public string Locale { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
