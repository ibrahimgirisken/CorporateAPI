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
        public List<GetPageDTO> Children { get; set; } = new List<GetPageDTO>();

        [JsonPropertyName("modules")]
        public List<ResultPageModuleDTO> Modules { get; set; } = new List<ResultPageModuleDTO>();

        [JsonPropertyName("translations")]
        public List<PageTranslationDTO> Translations { get; set; } = new List<PageTranslationDTO>();
    }
}
