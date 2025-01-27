using CorporateAPI.WebUI.Abstract;
using CorporateAPI.WebUI.DTOs.Lang;
using CorporateAPI.WebUI.DTOs.Module;
using CorporateAPI.WebUI.ViewModels.Module;
using Microsoft.AspNetCore.Mvc;

namespace CorporateAPI.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class ModuleController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IFileService _fileService;

        public ModuleController(IHttpClientFactory httpClientFactory, IFileService fileService)
        {
            _httpClientFactory = httpClientFactory;
            _fileService = fileService;
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

            string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "modules");

            moduleDto.Image1 = await _fileService.SaveFileAsync(moduleDto.Image1File, uploadPath);
            moduleDto.Image2 = await _fileService.SaveFileAsync(moduleDto.Image2File, uploadPath);
            moduleDto.Image3 = await _fileService.SaveFileAsync(moduleDto.Image3File, uploadPath);
            moduleDto.Video = await _fileService.SaveFileAsync(moduleDto.VideoFile, uploadPath);

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
            string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "modules");

            moduleDto.Image1 = await _fileService.UpdateFileAsync(moduleDto.Image1File, moduleDto.Image1, uploadPath);
            moduleDto.Image2 = await _fileService.UpdateFileAsync(moduleDto.Image2File, moduleDto.Image2, uploadPath);
            moduleDto.Image3 = await _fileService.UpdateFileAsync(moduleDto.Image3File, moduleDto.Image3, uploadPath);
            moduleDto.Video = await _fileService.UpdateFileAsync(moduleDto.VideoFile, moduleDto.Video, uploadPath);

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
