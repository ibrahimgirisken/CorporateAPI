using CorporateAPI.WebUI.DTOs.Home;
using CorporateAPI.WebUI.Helpers;
using CorporateAPI.WebUI.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Globalization;
using System.Net;

namespace CorporateAPI.WebUI.ViewComponents.Home
{
    public class _HomeSponsorComponent:ApiDataComponent<ResultHomeDTO>
    {
        public _HomeSponsorComponent(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await InvokeGenericAsync<ResultHomeDTO>("Homes/Home/sponsor");
        }
    }
}
