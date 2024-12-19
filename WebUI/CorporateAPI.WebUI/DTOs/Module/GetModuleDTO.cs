
namespace CorporateAPI.WebUI.DTOs.Module
{
    public class GetModuleDTO
    {
        public int Id { get; set; }
        public List<ModuleTranslationDTO> Translations { get; set; }
    }
}
