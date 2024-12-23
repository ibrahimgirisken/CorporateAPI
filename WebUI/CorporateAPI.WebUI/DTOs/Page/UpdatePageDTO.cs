
namespace CorporateAPI.WebUI.DTOs.Page
{
    public class UpdatePageDTO
    {
        public int Id { get; set; }
        public UpdatePageDTO()
        {
            Modules = new List<UpdatePageDTO>();
            Translations = new List<PageTranslationDTO>();
        }
        public int? ParentId { get; set; }
        public List<UpdatePageDTO> Modules { get; set; }
        public List<PageTranslationDTO> Translations { get; set; }
    }
}
