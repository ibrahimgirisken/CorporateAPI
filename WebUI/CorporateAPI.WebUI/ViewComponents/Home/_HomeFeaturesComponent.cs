using Microsoft.AspNetCore.Mvc;

namespace CorporateAPI.WebUI.ViewComponents.Home
{
	public class _HomeFeaturesComponent:ViewComponent
	{
		public IViewComponentResult Invoke()
		{

		return View(); 
		}
	}
}
