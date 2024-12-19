using CorporateAPI.WebUI.DTOs.PageModule;
using System.Text.Json.Serialization;

namespace CorporateAPI.WebUI.DTOs.Page
{
    public class GetPageDTO
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("children")]
        public List<GetPageDTO> Children { get; set; } = new();

        [JsonPropertyName("modules")]
        public List<ResultPageModuleDTO> Modules { get; set; } = new();

        [JsonPropertyName("translations")]
        public List<PageTranslationDTO> Translations { get; set; } = new();
    }
}
