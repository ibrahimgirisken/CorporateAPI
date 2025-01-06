using CorporateAPI.WebUI.DTOs.Module;
using CorporateAPI.WebUI.DTOs.Page;

namespace CorporateAPI.WebUI.ViewModels
{
    public class CreatePageViewModel
    {
        public CreatePageDTO CreatePageDTO { get; set; }
        public List<ResultModuleDTO> GetModuleDTOs { get; set; }
    }
}
