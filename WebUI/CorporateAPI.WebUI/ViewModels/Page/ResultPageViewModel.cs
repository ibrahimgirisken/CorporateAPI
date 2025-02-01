using CorporateAPI.Application.DTOs.Module;
using CorporateAPI.WebUI.DTOs.Menu;
using CorporateAPI.WebUI.DTOs.Page;

namespace CorporateAPI.WebUI.ViewModels.Page
{
    public class ResultPageViewModel
    {
      public ResultPageDTO ResultPageDTO { get; set; }
      public List<ResultMenuDTO> ResultMenuDTOs { get; set; }
      public ResultModuleDTO ResultModuleDTO { get; set; }
    }
}
