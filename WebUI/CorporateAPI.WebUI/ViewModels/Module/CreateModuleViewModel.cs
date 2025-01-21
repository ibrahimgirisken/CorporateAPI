using CorporateAPI.WebUI.DTOs.Lang;
using CorporateAPI.WebUI.DTOs.Module;

namespace CorporateAPI.WebUI.ViewModels.Module
{
    public class CreateModuleViewModel
    {
        public CreateModuleDTO CreateModuleDTO { get; set; }
        public List<ResultLangDTO> GetLangDTOs{ get; set; }
    }
}
