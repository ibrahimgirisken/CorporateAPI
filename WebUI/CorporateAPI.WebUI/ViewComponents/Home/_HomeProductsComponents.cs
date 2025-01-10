using Microsoft.AspNetCore.Mvc;

namespace CorporateAPI.WebUI.ViewComponents.Home
{
    public class _HomeProductsComponents: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
