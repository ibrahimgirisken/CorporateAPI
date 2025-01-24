using System.Text.Json.Serialization;

namespace CorporateAPI.WebUI.DTOs.Menu
{
    public class CreateMenuDTO
    {
        public CreateMenuDTO()
        {
            MenuTranslations = new List<MenuTranslationDTO>();
        }

        public bool Vitrin { get; set; }
        public bool Footer { get; set; }
        public int Order { get; set; }
        public bool Status { get; set; }
        public int? ParentId { get; set; }

        public List<MenuTranslationDTO> MenuTranslations { get; set; }
    }
}
