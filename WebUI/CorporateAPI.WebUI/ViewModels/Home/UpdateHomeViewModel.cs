using CorporateAPI.WebUI.DTOs.Home;
using CorporateAPI.WebUI.DTOs.Lang;
using CorporateAPI.WebUI.DTOs.Module;

namespace CorporateAPI.WebUI.ViewModels.Home
{
    public class UpdateHomeViewModel
    {
        public UpdateHomeDTO UpdateHomeDTO{ get; set; }
        public List<ResultLangDTO> GetLangDTOs{ get; set; }
    }
}
