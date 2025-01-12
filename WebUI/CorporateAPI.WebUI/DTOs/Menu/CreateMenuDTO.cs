namespace CorporateAPI.WebUI.DTOs.Menu
{
    public class CreateMenuDTO
    {
        public CreateMenuDTO()
        {
            Children = new HashSet<CreateMenuDTO>();
            MenuTranslations = new HashSet<MenuTranslationDTO>();
        }
        public bool Vitrin { get; set; }
        public bool Footer { get; set; }
        public int Order { get; set; }
        public int? ParentId { get; set; }
        public ICollection<CreateMenuDTO> Children { get; set; }
        public ICollection<MenuTranslationDTO> MenuTranslations { get; set; }
    }
}
