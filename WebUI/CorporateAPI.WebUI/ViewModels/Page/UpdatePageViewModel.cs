using CorporateAPI.WebUI.DTOs.Lang;
using CorporateAPI.WebUI.DTOs.Module;
using CorporateAPI.WebUI.DTOs.Page;

namespace CorporateAPI.WebUI.ViewModels.Page
{
    public class UpdatePageViewModel
    {
        public UpdatePageDTO UpdatePageDTO { get; set; }
        public List<ResultModuleDTO> GetModuleDTOs { get; set; }
        public List<ResultLangDTO> GetLangDTOs
        {
            get; set;
        }
    }
}
