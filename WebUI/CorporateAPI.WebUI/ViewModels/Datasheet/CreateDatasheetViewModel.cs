using CorporateAPI.WebUI.DTOs.Datasheet;
using CorporateAPI.WebUI.DTOs.Lang;

namespace CorporateAPI.WebUI.ViewModels.Datasheet
{
    public class CreateDatasheetViewModel
    {
        public CreateDatasheetDTO CreateDatasheetDTO { get; set; }
        public List<ResultLangDTO> GetLandDTOs { get; set; }
        public List<ResultDatasheetDTO> ResultDatasheets { get; set; }
    }
}
