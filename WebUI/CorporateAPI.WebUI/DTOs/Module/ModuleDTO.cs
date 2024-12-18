
namespace CorporateAPI.WebUI.DTOs.Module
{
    public class ModuleDTO
    {
        public ModuleDTO()
        {
            Translsations=new HashSet<ModuleTranslationDTO>();
        }
        public ICollection<ModuleTranslationDTO> Translsations { get; set; }

    }
}
