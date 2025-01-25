using CorporateAPI.WebUI.DTOs.Category;
using CorporateAPI.WebUI.DTOs.Datasheet;
using CorporateAPI.WebUI.DTOs.Lang;

namespace CorporateAPI.WebUI.ViewModels.Datasheet
{
    public class UpdateDatasheetViewModel
    {
        public UpdateDatasheetDTO UpdateDatasheetDTO { get; set; }
        public List<ResultLangDTO> GetLangDTOs { get; set; }
    }
}
