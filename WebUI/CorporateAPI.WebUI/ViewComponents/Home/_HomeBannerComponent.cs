using CorporateAPI.WebUI.DTOs.Banner;
using Microsoft.AspNetCore.Mvc;

namespace CorporateAPI.WebUI.ViewComponents.Home
{
    public class _HomeBannerComponent: ApiDataComponent<List<ResultBannerDTO>>
    {
        public _HomeBannerComponent(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await InvokeGenericAsync<List<ResultBannerDTO>>("Banners");
        }
    }
}
