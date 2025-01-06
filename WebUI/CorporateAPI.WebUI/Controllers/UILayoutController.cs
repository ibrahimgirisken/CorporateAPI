using Microsoft.AspNetCore.Mvc;

namespace CorporateAPI.WebUI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Layout()
        {
            return View();
        }
    }
}
