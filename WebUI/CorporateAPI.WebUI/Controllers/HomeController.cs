using CorporateAPI.WebUI.DTOs.Menu;
using CorporateAPI.WebUI.ViewModels.Page;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace CorporateAPI.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HomeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var language = RouteData.Values["language"]?.ToString() ?? CultureInfo.CurrentUICulture.Name;
            var client = _httpClientFactory.CreateClient("Admin");
            client.DefaultRequestHeaders.Add("Accept-Language", language);
            var response = await client.GetAsync("Menus");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"API error: {response.StatusCode}, Reason: {response.ReasonPhrase}");
            }

            var menuData = await response.Content.ReadFromJsonAsync<List<ResultMenuDTO>>();
            ViewBag.MenuData = menuData;
            return View();
        }
    }
}
