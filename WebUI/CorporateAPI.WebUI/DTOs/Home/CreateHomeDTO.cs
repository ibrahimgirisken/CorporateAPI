namespace CorporateAPI.WebUI.DTOs.Home
{
    public class CreateHomeDTO
    {
        public CreateHomeDTO()
        {
            HomeTranslations = new List<HomeTranslationDTO>();
        }
        public string ContentType { get; set; }
        public int Order { get; set; }
        public bool Status { get; set; }
        public List<HomeTranslationDTO> HomeTranslations { get; set; }
    }
}
