using System.Text.Json.Serialization;
namespace CorporateAPI.WebUI.DTOs.Module
{
    public class CreateModuleDTO
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("translations")]
        public List<ModuleTranslationDTO> Translations { get; set; } = new List<ModuleTranslationDTO>();

    }
}
