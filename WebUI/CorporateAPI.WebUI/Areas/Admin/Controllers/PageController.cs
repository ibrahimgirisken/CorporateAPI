using CorporateAPI.WebUI.DTOs.Page;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace CorporateAPI.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class PageController: Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public PageController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient("Admin");
            var response = await client.GetAsync("Pages?IncludeAllLanguages=true");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"API error: {response.StatusCode}, Reason: {response.ReasonPhrase}");
            }
            var pagesData = await response.Content.ReadFromJsonAsync<List<ResultPageDTO>>();
            return View(pagesData);
        }
        [HttpGet]
        public async Task<IActionResult> CreatePage()
        {
            //var modules = await _client.GetFromJsonAsync<List<ResultModuleDTO>>("Modules");
            //var langs = await _client.GetFromJsonAsync<List<ResultLangDTO>>("Langs");
            //var model = new CreatePageDTO
            //{
            //    PageTranslations = langs.Select(lang => new PageTranslationDTO { Locale = lang.LangCode}).ToList()
            //};
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreatePage(CreatePageDTO pageDTO)
        {
            //await _client.PostAsJsonAsync("Pages", pageDTO);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> UpdatePage(int id)
        {
            //CreatePageDTO response= await _client.GetFromJsonAsync<CreatePageDTO>($"Pages/{id}");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePage(UpdatePageDTO updatePageDTO)
        {
            //await _client.PutAsJsonAsync("Pages", updatePageDTO);
            return RedirectToAction(nameof(Index));
        }
        [HttpDelete]
        public async Task<IActionResult> DeletePage(int id)
        {
            //await _client.DeleteAsync("Pages/{id}");
            return RedirectToAction(nameof(Index));
        }

    }
}
