using CorporateAPI.WebUI.DTOs.Category;
using CorporateAPI.WebUI.DTOs.Lang;
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
            var CreateCategoryDTO = new ResultCategoryDTO
            {
                CategoryTranslations = langs.Select(lang => new CategoryTranslationDTO
                {
                    Locale=lang.LangCode
                }).ToList()
            };
        }
    }
}
