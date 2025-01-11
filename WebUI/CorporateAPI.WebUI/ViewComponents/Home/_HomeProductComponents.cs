using Microsoft.AspNetCore.Mvc;

namespace CorporateAPI.WebUI.ViewComponents.Home
{
    public class _HomeProductsComponent: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
