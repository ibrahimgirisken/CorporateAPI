using CorporateAPI.WebUI.DTOs.Datasheet;
using CorporateAPI.WebUI.DTOs.Lang;

namespace CorporateAPI.WebUI.ViewModels.Datasheet
{
    public class CreateDatasheetViewModel
    {
        public CreateDatasheetDTO CreateDatasheetDTO { get; set; }
        public List<ResultLangDTO> GetLangDTOs { get; set; }
    }
}
