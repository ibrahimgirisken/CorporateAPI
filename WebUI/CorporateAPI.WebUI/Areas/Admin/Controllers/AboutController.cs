using CorporateAPI.WebUI.DTOs.Page;
using CorporateAPI.WebUI.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace CorporateAPI.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class AboutController() : Controller
    {
        private readonly HttpClient _client=HttpClientInstance.CreateClient();
        public async Task<IActionResult> Index()
        {
            var model = await _client.GetFromJsonAsync<List<GetPageDTO>>("Pages");

            if (model == null)
            {
                return View(new List<GetPageDTO>()); // Eğer API null dönerse boş bir liste gönder
            }

            return View(model);
        }
    }
}
