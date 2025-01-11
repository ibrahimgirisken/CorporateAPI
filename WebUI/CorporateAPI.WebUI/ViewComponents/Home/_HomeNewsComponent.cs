using Microsoft.AspNetCore.Mvc;

namespace CorporateAPI.WebUI.ViewComponents.Home
{
	public class _HomeNewsComponent:ViewComponent
	{
		public IViewComponentResult Invoke()
		{

		return View(); }
	}
}
