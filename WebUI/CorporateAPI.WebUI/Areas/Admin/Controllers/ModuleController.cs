using CorporateAPI.WebUI.DTOs.Lang;
using CorporateAPI.WebUI.DTOs.Module;
using Microsoft.AspNetCore.Mvc;

namespace CorporateAPI.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class ModuleController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ModuleController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient("Admin");
            var response = await client.GetAsync("Modules?IncludeAllLanguages=true");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"API error: {response.StatusCode}, Reason: {response.ReasonPhrase}");
            }
            var modulesData = await response.Content.ReadFromJsonAsync<List<ResultModuleDTO>>();
            return View(modulesData);
        }
        [HttpGet]
        public async Task<IActionResult> CreateModule()
        {
            var client = _httpClientFactory.CreateClient("Admin");
            var langs = await client.GetFromJsonAsync<List<ResultLangDTO>>("Langs");
            var createModuleDTO = new CreateModuleDTO
            {
                ModuleTranslations = langs.Select(lang => new ModuleTranslationDTO
                {
                    Locale=lang.LangCode,
                }).ToList(),
            };
            return View(createModuleDTO);
        }
        [HttpPost]
        public async Task<IActionResult> CreateModule(CreateModuleDTO moduleDTO)
        {
            return null;
        }

        [HttpGet]
        public IActionResult UpdateModule()
        {
            return null;
        }

        [HttpPost]
        public async Task<IActionResult> UpdateModule(UpdateModuleDTO updateModuleDTO)
        {
            return null;
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteModule()
        {
            return null;
        }
    }
}
