
namespace CorporateAPI.WebUI.DTOs.Menu
{
    public class GetByIdMenuDTO
    {
        public int Id { get; set; }
        public bool Vitrin { get; set; }
        public bool Footer { get; set; }
        public int Order { get; set; }
        public int? ParentId { get; set; }
        public ICollection<MenuTranslationDTO> MenuTranslations { get; set; }
    }
}
