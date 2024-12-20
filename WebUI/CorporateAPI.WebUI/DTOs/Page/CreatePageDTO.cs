
namespace CorporateAPI.WebUI.DTOs.Page
{
    public class CreatePageDTO
    {
         public CreatePageDTO()
        {
            PageModuleIds = new List<int?>();
            Translations=new List<PageTranslationDTO>();
        }
        public int? ParentId { get; set; }
        public List<int?> PageModuleIds { get; set; }
        public List<PageTranslationDTO> Translations { get; set; }
    }
}
