using CorporateAPI.WebUI.DTOs.Lang;
using CorporateAPI.WebUI.DTOs.Module;
using CorporateAPI.WebUI.DTOs.Page;
using CorporateAPI.WebUI.ViewModels.Page;
using Microsoft.AspNetCore.Mvc;

namespace CorporateAPI.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class PageController : Controller
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
            var client = _httpClientFactory.CreateClient("Admin");
            var modules = await client.GetFromJsonAsync<List<ResultModuleDTO>>("Modules");
            var langs = await client.GetFromJsonAsync<List<ResultLangDTO>>("Langs");
            var CreatePageDTO = new CreatePageDTO
            {
                PageTranslations = langs.Select(lang => new PageTranslationDTO
                {
                    Locale = lang.LangCode 
                }).ToList()
            };
            var model = new CreatePageViewModel
            {
                CreatePageDTO = CreatePageDTO,
                GetLangDTOs = langs,
                GetModuleDTOs = modules
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> CreatePage(CreatePageViewModel createPageViewModel)
        {
            CreatePageDTO pageDto = createPageViewModel.CreatePageDTO;
            var client = _httpClientFactory.CreateClient("Admin");
            await client.PostAsJsonAsync<CreatePageDTO>("Pages", pageDto);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> UpdatePage(int id)
        {
            var client = _httpClientFactory.CreateClient("Admin");
            var modules = await client.GetFromJsonAsync<List<ResultModuleDTO>>("Modules");
            var langs = await client.GetFromJsonAsync<List<ResultLangDTO>>("Langs");
            var resultPageDTO = await client.GetFromJsonAsync<UpdatePageDTO>($"Pages/{id}");
            var model = new UpdatePageViewModel
            {
                UpdatePageDTO = resultPageDTO,
                GetLangDTOs = langs,
                GetModuleDTOs = modules
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePage(UpdatePageViewModel updatePageViewModel)
        {
            UpdatePageDTO pageDto = updatePageViewModel.UpdatePageDTO;
            var client = _httpClientFactory.CreateClient("Admin");
            await client.PutAsJsonAsync<UpdatePageDTO>("Pages", pageDto);
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
