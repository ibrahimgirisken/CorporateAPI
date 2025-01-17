using CorporateAPI.WebUI.DTOs.Home;
using CorporateAPI.WebUI.Helpers;
using CorporateAPI.WebUI.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CorporateAPI.WebUI.ViewComponents.Home
{
	public class _HomeAboutComponent:ViewComponent
	{
		HttpClient _client=HttpClientInstance.CreateClient();
        public async Task<IViewComponentResult> InvokeAsync()
		{
            var values = await _client.GetFromJsonAsync<ResultHomeDTO>("Homes/Home/about");
            if (values == null)
            {
                return View(new List<ResultHomeDTO>());
            }
            return View(values);
        }
	}
}
