using CorporateAPI.WebUI.DTOs.Home;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace CorporateAPI.WebUI.ViewComponents.Home
{
    public class _HomeAboutComponent:ApiDataComponent<ResultHomeDTO>
	{
        public _HomeAboutComponent(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }
        public async Task<IViewComponentResult> InvokeAsync()
		{
           return await InvokeGenericAsync<ResultHomeDTO>("Homes/Home/about");
        }
	}
}
