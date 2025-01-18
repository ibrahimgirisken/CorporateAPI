using CorporateAPI.WebUI.DTOs.Home;
using CorporateAPI.WebUI.Helpers;
using CorporateAPI.WebUI.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace CorporateAPI.WebUI.ViewComponents.Home
{
    public class _HomeSponsorComponent:ApiDataComponent<ResultHomeDTO>
	{
		IDetectionService _detectionService;

        public _HomeSponsorComponent(IDetectionService detectionService)
        {
            _detectionService = detectionService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var language = _detectionService.GetLanguage();
            var url = "Homes/Home/sponsor";
            return await InvokeGenericAsync(url);
        }
    }
}
