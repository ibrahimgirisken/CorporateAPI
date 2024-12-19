using System.Text.Json.Serialization;
namespace CorporateAPI.WebUI.DTOs.Page
{
    public class PageTranslationDTO
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("locale")]
        public string Locale { get; set; }
    }
}
