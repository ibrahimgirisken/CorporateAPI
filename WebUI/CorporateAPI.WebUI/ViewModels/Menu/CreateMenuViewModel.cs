using CorporateAPI.WebUI.DTOs.Lang;
using CorporateAPI.WebUI.DTOs.Menu;

namespace CorporateAPI.WebUI.ViewModels.Menu
{
    public class CreateMenuViewModel
    {
        public CreateMenuDTO CreateMenuDTO { get; set; }
        public List<ResultLangDTO> GetLangDTOs
        {
            get; set;
        }
    }
}
