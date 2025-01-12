using CorporateAPI.WebUI.DTOs.Lang;
using CorporateAPI.WebUI.DTOs.Module;
using CorporateAPI.WebUI.DTOs.Page;
using CorporateAPI.WebUI.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace CorporateAPI.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class PageController() : Controller
    {
        private readonly HttpClient _client= HttpClientInstance.CreateClient();
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var response = await _client.GetFromJsonAsync<List<ResultPageDTO>>("Pages");

            if (response == null)
            {
                return View(new List<ResultPageDTO>());
            }

            return View(response);
        }
        [HttpGet]
        public async Task<IActionResult> CreatePage()
        {
            var modules = await _client.GetFromJsonAsync<List<ResultModuleDTO>>("Modules");
            var langs = await _client.GetFromJsonAsync<List<ResultLangDTO>>("Langs");
            var model = new CreatePageDTO
            {
                PageTranslations = langs.Select(lang => new PageTranslationDTO { Locale = lang.LangCode}).ToList()
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> CreatePage(CreatePageDTO pageDTO)
        {
            await _client.PostAsJsonAsync("Pages", pageDTO);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> UpdatePage(int id)
        {
            CreatePageDTO response= await _client.GetFromJsonAsync<CreatePageDTO>($"Pages/{id}");
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePage(UpdatePageDTO updatePageDTO)
        {
            await _client.PutAsJsonAsync("Pages", updatePageDTO);
            return RedirectToAction(nameof(Index));
        }
        [HttpDelete]
        public async Task<IActionResult> DeletePage(int id)
        {
            await _client.DeleteAsync("Pages/{id}");
            return RedirectToAction(nameof(Index));
        }

    }
}
