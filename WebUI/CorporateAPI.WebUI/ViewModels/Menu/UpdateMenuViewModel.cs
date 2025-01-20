using CorporateAPI.WebUI.DTOs.Lang;
using CorporateAPI.WebUI.DTOs.Menu;

namespace CorporateAPI.WebUI.ViewModels.Menu
{
    public class UpdateMenuViewModel
    {
        public UpdateMenuDTO UpdateMenuDTO { get; set; }
        public List<ResultMenuDTO> ResultMenus { get; set; }
        public List<ResultLangDTO> GetLangDTOs
        {
            get; set;
        }
    }
}
