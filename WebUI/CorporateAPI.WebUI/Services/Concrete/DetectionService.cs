using CorporateAPI.WebUI.Services.Abstract;

namespace CorporateAPI.WebUI.Services.Concrete
{
    public class DetectionService : IDetectionService
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public DetectionService(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }
        public string GetLanguage()
        {
            var language = httpContextAccessor.HttpContext?.GetRouteValue("languages")?.ToString();
            return language;
        }

    }
}
