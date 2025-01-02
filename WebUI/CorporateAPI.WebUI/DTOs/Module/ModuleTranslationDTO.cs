using System.Text.Json.Serialization;
namespace CorporateAPI.WebUI.DTOs.Module
{
    public class ModuleTranslationDTO
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("locale")]
        public string Locale { get; set; }
        [JsonPropertyName("moduleData")]
        public string ModuleData { get; set; }
    }
}
