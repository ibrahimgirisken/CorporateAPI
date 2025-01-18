using CorporateAPI.WebUI.DTOs.Home;
using CorporateAPI.WebUI.Helpers;
using CorporateAPI.WebUI.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
namespace CorporateAPI.WebUI.ViewComponents.Home
{
    public class _HomeAboutComponent:ApiDataComponent<ResultHomeDTO>
	{
        IDetectionService _detectionService;

        public _HomeAboutComponent(IDetectionService detectionService)
        {
            _detectionService = detectionService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
		{
            var language=_detectionService.GetLanguage();
            var url = "Homes/Home/about";
            return await InvokeGenericAsync(url);
        }
	}
}
