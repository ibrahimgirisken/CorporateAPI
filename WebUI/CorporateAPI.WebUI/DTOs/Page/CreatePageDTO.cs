
namespace CorporateAPI.WebUI.DTOs.Page
{
    public class CreatePageDTO
    {
         public CreatePageDTO()
        {
            Translations = new HashSet<PageTranslationDTO>();
        }
        public string? Image1 { get; set; }
        public string? Image2 { get; set; }
        public string? Image3 { get; set; }
        public int Order { get; set; }= 0;
        public string ModuleIds { get; set; } = "0";
        public ICollection<PageTranslationDTO> Translations { get; set; }
    }
}
