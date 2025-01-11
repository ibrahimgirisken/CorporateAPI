using Microsoft.AspNetCore.Mvc;

namespace CorporateAPI.WebUI.ViewComponents.Home
{
	public class _HomeVideoComponent:ViewComponent
	{
		public IViewComponentResult Invoke()
		{

		return View(); }
	}
}
