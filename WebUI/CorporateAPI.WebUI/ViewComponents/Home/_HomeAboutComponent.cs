using CorporateAPI.WebUI.DTOs.Home;
using CorporateAPI.WebUI.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace CorporateAPI.WebUI.ViewComponents.Home
{
	public class _HomeAboutComponent:ViewComponent
	{
		HttpClient _client=HttpClientInstance.CreateClient();
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var about =await _client.GetFromJsonAsync<ResultHomeDTO>("Home/about");
			return View(about); 
		}
	}
}
