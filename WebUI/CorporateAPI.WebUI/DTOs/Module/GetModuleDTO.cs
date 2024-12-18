
namespace CorporateAPI.WebUI.DTOs.Module
{
    public class GetModuleDTO
    {
        public int Id { get; set; }
        public ICollection<ModuleTranslationDTO> Translations { get; set; }
    }
}
