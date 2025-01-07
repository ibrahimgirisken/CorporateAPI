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
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("desktopImage")]
        public string DesktopImage { get; set; }
        [JsonPropertyName("tableteImage")]
        public string TableteImage { get; set; }
        [JsonPropertyName("mobileImage")]
        public string MobileImage { get; set; }
        [JsonPropertyName("order")]
        public int Order { get; set; }
        public ICollection<BannerTranslationDTO> BannerTranslations { get; set; }
    }
}
