namespace CorporateAPI.WebUI.DTOs.Datasheet
{
    public class UpdateDatasheetDTO
    {
        public int Id { get; set; }
        public UpdateDatasheetDTO()
        {
            DatasheetTranslations = new List<DatasheetTranslationDTO>();
        }
        public string? Code { get; set; }
        public string? Image1 { get; set; }
        public int Order { get; set; }
        public bool Status { get; set; }
        public List<DatasheetTranslationDTO> DatasheetTranslations { get; set; }
    }
}
