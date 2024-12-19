using Microsoft.AspNetCore.Mvc;

namespace CorporateAPI.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
