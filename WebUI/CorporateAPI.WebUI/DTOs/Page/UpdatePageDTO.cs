
namespace CorporateAPI.WebUI.DTOs.Page
{
    public class UpdatePageDTO
    {
        public int Id { get; set; }
        public UpdatePageDTO()
        {
            PageModuleIds = new List<int?>();
        }
        public int? ParentId { get; set; }
        public List<int?> PageModuleIds { get; set; }
        public List<PageTranslationDTO> Translations { get; set; }
    }
}
