using CorporateAPI.WebUI.DTOs.Page;
using CorporateAPI.WebUI.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace CorporateAPI.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class AboutController() : Controller
    {
        private readonly HttpClient _client= HttpClientInstance.CreateClient();
        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<GetPageDTO>>("Pages");

            if (values == null)
            {
                return View(new List<GetPageDTO>()); // Eğer API null dönerse boş bir liste gönder
            }

            return View(values);
        }
    }
}
