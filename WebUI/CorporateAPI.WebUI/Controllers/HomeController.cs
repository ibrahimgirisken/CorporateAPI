using CorporateAPI.WebUI.DTOs.Menu;
using CorporateAPI.WebUI.DTOs.Setting;
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
            var responseMenu = await client.GetAsync("Menus");
            var responseSetting = await client.GetAsync("Settings/1");

            if (!responseMenu.IsSuccessStatusCode)
            {
                throw new Exception($"API error: {responseMenu.StatusCode}, Reason: {responseMenu.ReasonPhrase}");
            }

            var menuData = await responseMenu.Content.ReadFromJsonAsync<List<ResultMenuDTO>>();
            var settingData = await responseSetting.Content.ReadFromJsonAsync<ResultSettingDTO>();
            ViewBag.SettingData = settingData;
            ViewBag.MenuData = menuData;
            return View();
        }
    }
}
