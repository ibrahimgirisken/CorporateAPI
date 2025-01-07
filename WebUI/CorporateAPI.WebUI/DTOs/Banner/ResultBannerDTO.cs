using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CorporateAPI.WebUI.DTOs.Banner
{
    public class ResultBannerDTO
    {
        public int Id { get; set; }
        public string DesktopImage { get; set; }
        public string TableteImage { get; set; }
        public string MobileImage { get; set; }
        public int Order { get; set; }
        public ICollection<BannerTranslationDTO> BannerTranslations { get; set; }
    }
}
