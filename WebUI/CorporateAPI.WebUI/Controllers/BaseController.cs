using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Globalization;

namespace CorporateAPI.WebUI.Controllers
{
    public class BaseController : Controller
    {
        public string LANGUAGE_CODE()
        {
            return CultureInfo.CurrentCulture.Name;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var culture = context.RouteData.Values["culture"]?.ToString() ?? "en";

            var cultureInfo = new CultureInfo(culture);
            CultureInfo.CurrentCulture = cultureInfo;
            CultureInfo.CurrentUICulture = cultureInfo;

            await next();
        }
    }
}
