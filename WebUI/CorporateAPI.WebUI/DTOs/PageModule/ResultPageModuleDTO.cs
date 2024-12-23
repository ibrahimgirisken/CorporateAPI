using System.Text.Json.Serialization;
using CorporateAPI.WebUI.DTOs.Module;

namespace CorporateAPI.WebUI.DTOs.PageModule
{
    public class ResultPageModuleDTO
    {
        [JsonPropertyName("pageId")]
        public int PageId { get; set; }

        [JsonPropertyName("moduleId")]
        public int ModuleId { get; set; }

        [JsonPropertyName("order")]
        public int Order { get; set; }

        [JsonPropertyName("module")]
        public CreateModuleDTO Module { get; set; } = new CreateModuleDTO();

    }
}
