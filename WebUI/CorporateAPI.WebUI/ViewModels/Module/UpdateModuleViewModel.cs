using CorporateAPI.WebUI.DTOs.Lang;
using CorporateAPI.WebUI.DTOs.Module;

namespace CorporateAPI.WebUI.ViewModels.Module
{
    public class UpdateModuleViewModel
    {
        public UpdateModuleDTO UpdateModuleDTO { get; set; }
        public List<ResultLangDTO> GetLangDTOs { get; set; }
    }
}
