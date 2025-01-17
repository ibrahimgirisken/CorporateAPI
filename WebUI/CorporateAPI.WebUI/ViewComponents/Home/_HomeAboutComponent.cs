using CorporateAPI.WebUI.DTOs.Home;
using CorporateAPI.WebUI.Helpers;
using CorporateAPI.WebUI.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CorporateAPI.WebUI.ViewComponents.Home
{
	public class _HomeAboutComponent:ViewComponent
	{
		HttpClient _client=HttpClientInstance.CreateClient();
        IDetectionService _detectionService;

        public _HomeAboutComponent(IDetectionService detectionService)
        {
            _detectionService = detectionService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
		{
            var language=_detectionService.GetLanguage();
            var values = await _client.GetFromJsonAsync<ResultHomeDTO>("Homes/Home/about");
            if (values == null)
            {
                return View(new ResultHomeDTO());
            }
            return View(values);
        }
	}
}
