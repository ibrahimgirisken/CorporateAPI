using Microsoft.AspNetCore.Mvc;

namespace CorporateAPI.WebUI.ViewComponents.Home
{
	public class _HomeServiceComponent:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
		return View(); 
		}
	}
}
