using CorporateAPI.WebUI.DTOs.Lang;
using CorporateAPI.WebUI.DTOs.Module;
using CorporateAPI.WebUI.DTOs.Page;
using CorporateAPI.WebUI.ViewModels.Menu;
using CorporateAPI.WebUI.ViewModels.Module;
using CorporateAPI.WebUI.ViewModels.Page;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;

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
            var model = new CreateModuleViewModel
            {
                CreateModuleDTO = createModuleDTO,
                GetLangDTOs=langs
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> CreateModule(CreateModuleViewModel createModuleViewModel)
        {
            CreateModuleDTO moduleDto = createModuleViewModel.CreateModuleDTO;
            var client = _httpClientFactory.CreateClient("Admin");
            await client.PostAsJsonAsync<CreateModuleDTO>("Modules", moduleDto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> UpdateModule(int id)
        {
            var client = _httpClientFactory.CreateClient("Admin");
            var langs = await client.GetFromJsonAsync<List<ResultLangDTO>>("Langs");
            var resultModuleDTO = await client.GetFromJsonAsync<UpdateModuleDTO>($"Modules/{id}");
            var model = new UpdateModuleViewModel
            {
                UpdateModuleDTO = resultModuleDTO,
                GetLangDTOs = langs,
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateModule(UpdateModuleViewModel updateModuleViewModel)
        {
            UpdateModuleDTO moduleDto = updateModuleViewModel.UpdateModuleDTO;
            var client = _httpClientFactory.CreateClient("Admin");
            await client.PutAsJsonAsync<UpdateModuleDTO>("Modules", moduleDto);
            return RedirectToAction(nameof(Index));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteModule()
        {
            return RedirectToAction(nameof(Index));
        }
    }
}
