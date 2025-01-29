using CorporateAPI.WebUI.DTOs.Menu;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace CorporateAPI.WebUI.Controllers
{
    public class PageController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public PageController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet("{language}/{*urlAddress}")]
        public async Task<IActionResult> GetByLanguageAndUrl(string language, string urlAddress)
        {
            language = RouteData.Values["language"]?.ToString() ?? CultureInfo.CurrentUICulture.Name;
            var client = _httpClientFactory.CreateClient("Admin");
            client.DefaultRequestHeaders.Add("Accept-Language", language);



            var apiUrl = $"Pages/Page/{urlAddress}?language={language}";
            var responsePage=await client.GetAsync(apiUrl);
            if (!responsePage.IsSuccessStatusCode)
            {
                throw new Exception($"API error: {responsePage.StatusCode}, Reason: {responsePage.ReasonPhrase}");
            }

            var responseMenu = await client.GetAsync("Menus");
            var menuData = await responseMenu.Content.ReadFromJsonAsync<List<ResultMenuDTO>>();
            ViewBag.MenuData = menuData;
            var dataPage = await responsePage.Content.ReadFromJsonAsync<DTOs.Page.ResultPageDTO>();

            return View(dataPage);
        }

    }
}
