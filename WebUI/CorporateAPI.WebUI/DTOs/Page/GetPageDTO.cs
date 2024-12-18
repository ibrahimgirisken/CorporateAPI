using CorporateAPI.WebUI.DTOs.PageModule;

namespace CorporateAPI.WebUI.DTOs.Page
{
    public class GetPageDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<GetPageDTO?> Children { get; set; }
        public ICollection<ResultPageModuleDTO?> Modules { get; set; }
        public ICollection<PageTranslationDTO> Translations { get; set; }

    }
}
