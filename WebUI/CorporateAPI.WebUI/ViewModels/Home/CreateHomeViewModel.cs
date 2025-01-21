using CorporateAPI.WebUI.DTOs.Home;
using CorporateAPI.WebUI.DTOs.Lang;

namespace CorporateAPI.WebUI.ViewModels.Home
{
    public class CreateHomeViewModel
    {
        public CreateHomeDTO CreateHomeDTO{ get; set; }
        public List<ResultLangDTO> GetLangDTOs{ get; set; }
    }
}
