using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CorporateAPI.WebUI.Controllers
{
    public class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var language = HttpContext.Request.Headers["Accept-Language"].ToString();

            if (string.IsNullOrEmpty(language))
            {
                language = "en"; // Varsayılan dil
            }

            // Dil bilgisini HttpContext.Items içine kaydediyoruz
            HttpContext.Items["Language"] = language;
        }
    }
}
