namespace CorporateAPI.WebUI.DTOs.Home
{
    public class CreateHomeDTO
    {
        public CreateHomeDTO()
        {
            HomeTranslations = new HashSet<HomeTranslationDTO>();
        }
        public int Id { get; set; }
        public string ContentType { get; set; }
        public int Order { get; set; }
        public bool Status { get; set; }
        public ICollection<HomeTranslationDTO> HomeTranslations { get; set; }
    }
}
