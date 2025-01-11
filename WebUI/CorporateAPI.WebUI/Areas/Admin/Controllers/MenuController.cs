using CorporateAPI.WebUI.DTOs.Menu;
using CorporateAPI.WebUI.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace CorporateAPI.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class MenuController : Controller
    {
        private readonly HttpClient _client=HttpClientInstance.CreateClient();
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultMenuDTO>>("menus");
            return View(values);
        }
    }
}
