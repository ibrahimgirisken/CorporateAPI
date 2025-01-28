namespace CorporateAPI.WebUI.DTOs.Setting
{
    public class CreateSettingDTO
    {
        public CreateSettingDTO()
        {
            SettingTranslations = new List<SettingTranslationDTO>();
        }
        public string? WhiteLogo { get; set; }
        public string? BlackLogo { get; set; }
        public IFormFile? WhiteLogoFile { get; set; }
        public IFormFile? BlackLogoFile { get; set; }
        public string? Telephone { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Facebook { get; set; }
        public string? Twitter { get; set; }
        public string? Instagram { get; set; }
        public string? LinkedIn { get; set; }
        public string? Youtube { get; set; }
        public string? GooglePlus { get; set; }
        public string? GoogleAnalytics { get; set; }
        public string? GoogleRecaptcha { get; set; }
        public string? GoogleTagManager { get; set; }
        public string? GoogleSiteVerification { get; set; }
        public string? GoogleMaps { get; set; }
        public bool Status { get; set; }
        public List<SettingTranslationDTO> SettingTranslations { get; set; }
    }
}
