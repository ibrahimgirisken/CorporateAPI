using Microsoft.AspNetCore.Mvc;

namespace CorporateAPI.WebUI.ViewComponents.Home
{
	public class _HomeAboutComponent:ViewComponent
	{
		public IViewComponentResult Invoke()
		{

		return View(); 
		}
	}
}
