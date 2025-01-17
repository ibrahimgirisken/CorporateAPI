using CorporateAPI.WebUI.Services.Abstract;

namespace CorporateAPI.WebUI.Services.Concrete
{
    public class DetectionService : IDetectionService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DetectionService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetLanguage()
        {
            var language = _httpContextAccessor.HttpContext?.GetRouteValue("culture")?.ToString();

            if (string.IsNullOrEmpty(language))
            {
                var languageHeader = _httpContextAccessor.HttpContext?.Request.Headers["Accept-Language"].ToString();
                language = languageHeader?.Split(',').FirstOrDefault()?.Split('-').FirstOrDefault();
            }

            return string.IsNullOrEmpty(language) ? "en" : language;
        }

    }
}
