using CoreporateAPI.Infrastructure.Operations;
using CorporateAPI.WebUI.Abstract;
using CorporateAPI.WebUI.DTOs.Banner;
using CorporateAPI.WebUI.DTOs.Category;
using CorporateAPI.WebUI.DTOs.Lang;
using CorporateAPI.WebUI.DTOs.Menu;
using CorporateAPI.WebUI.ViewModels.Category;
using Microsoft.AspNetCore.Mvc;

namespace CorporateAPI.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IFileService _fileService;

        public CategoryController(IHttpClientFactory httpClientFactory, IFileService fileService)
        {
            _httpClientFactory = httpClientFactory;
            _fileService = fileService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client=_httpClientFactory.CreateClient("Admin");
            var response = await client.GetAsync("Categories?IncludeAllLanguages=true");
            if (response == null)
            {
                throw new Exception($"API error: {response.StatusCode}, Reason: {response.ReasonPhrase}");
            }
            var categoriesData = await response.Content.ReadFromJsonAsync<List<ResultCategoryDTO>>();
            return View(categoriesData);
        }

        [HttpGet]
        public async Task<IActionResult> CreateCategory()
        {
            var client = _httpClientFactory.CreateClient("Admin");
            var langs = await client.GetFromJsonAsync<List<ResultLangDTO>>("Langs");
            var categories = await client.GetFromJsonAsync<List<ResultCategoryDTO>>("Categories?IncludeAllLanguages=true");
            var CreateCategoryDTO = new CreateCategoryDTO
            {
                CategoryTranslations = langs.Select(lang => new CategoryTranslationDTO
                {
                    Locale=lang.LangCode
                }).ToList()
            };
            var model = new CreateCategoryViewModel
            {
                CreateCategoryDTO = CreateCategoryDTO,
                GetLangDTOs = langs,
                ResultCategories= categories
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryViewModel createCategoryViewModel)
        {
            CreateCategoryDTO categoryDTO=createCategoryViewModel.CreateCategoryDTO;

            string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "categories");
            categoryDTO.Image1 = await _fileService.SaveFileAsync(categoryDTO.Image1File, uploadPath);

            var client = _httpClientFactory.CreateClient("Admin");

            NameOperation.ApplyCharacterRegulationToProperties(
                 categoryDTO.CategoryTranslations,
                 item => item.Url ?? item.Title,
                 (item, value) => item.Url = value
             );

            await client.PostAsJsonAsync<CreateCategoryDTO>("Categories", categoryDTO);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id)
        {
            var client = _httpClientFactory.CreateClient("Admin");
            var langs = await client.GetFromJsonAsync<List<ResultLangDTO>>("Langs");
            var resultCategoryDTO = await client.GetFromJsonAsync<UpdateCategoryDTO>($"Categories/{id}");
            var categories = await client.GetFromJsonAsync<List<ResultCategoryDTO>>("Categories?IncludeAllLanguges=true");
            var model = new UpdateCategoryViewModel
            {
                GetLangDTOs = langs,
                UpdateCategoryDTO = resultCategoryDTO,
                ResultCategories= categories
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryViewModel updateCategoryViewModel)
        {
            UpdateCategoryDTO updateCategoryDTO=updateCategoryViewModel.UpdateCategoryDTO;
            var client = _httpClientFactory.CreateClient("Admin");

            string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "categories");
            
            updateCategoryDTO.Image1 = await _fileService.UpdateFileAsync(updateCategoryDTO.Image1File, updateCategoryDTO.Image1, uploadPath);

            NameOperation.ApplyCharacterRegulationToProperties(
                updateCategoryDTO.CategoryTranslations,
                item => item.Url ?? item.Title,
                (item, value) => item.Url = value
            );

            await client.PutAsJsonAsync<UpdateCategoryDTO>("Categories",updateCategoryDTO);
            return RedirectToAction(nameof(Index));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            return RedirectToAction(nameof(Index));
        }
    }
}
