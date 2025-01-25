using CorporateAPI.WebUI.DTOs.Lang;
using CorporateAPI.WebUI.DTOs.Setting;

namespace CorporateAPI.WebUI.ViewModels.Setting
{
    public class ResultSettingViewModel
    {
        public ResultSettingDTO ResultSettingDTO { get; set; }
        public List<ResultLangDTO> GetLangDTOs { get; set; }
    }
}
