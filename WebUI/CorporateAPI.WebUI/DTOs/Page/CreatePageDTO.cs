
namespace CorporateAPI.WebUI.DTOs.Page
{
    public class CreatePageDTO
    {
         public CreatePageDTO()
        {
            PageModuleIds = new List<int?>();
            Translations=new List<PageTranslationDTO>();
        }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public int Order { get; set; }
        public int? ParentId { get; set; }
        public List<int?> PageModuleIds { get; set; }
        public List<PageTranslationDTO> Translations { get; set; }
    }
}
