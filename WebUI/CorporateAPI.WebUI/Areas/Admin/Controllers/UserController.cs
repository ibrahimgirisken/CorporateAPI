using Microsoft.AspNetCore.Mvc;

namespace CorporateAPI.WebUI.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
