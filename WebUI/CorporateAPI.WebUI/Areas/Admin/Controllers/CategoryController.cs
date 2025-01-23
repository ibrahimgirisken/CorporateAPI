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

        public CategoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
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
            var client = _httpClientFactory.CreateClient("Admin");
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
