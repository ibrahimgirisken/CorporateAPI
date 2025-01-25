using CorporateAPI.WebUI.DTOs.Home;
using CorporateAPI.WebUI.DTOs.Lang;
using CorporateAPI.WebUI.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;

namespace CorporateAPI.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HomeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient("Admin");
            var response = await client.GetAsync("Homes?IncludeAllLanguages=true");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"API error: {response.StatusCode}, Reason: {response.ReasonPhrase}");
            }
            var homesData = await response.Content.ReadFromJsonAsync<List<ResultHomeDTO>>();
            return View(homesData);
        }

        [HttpGet]

        public async Task<IActionResult> CreateHome()
        {
            var client = _httpClientFactory.CreateClient("Admin");
            var homes = await client.GetFromJsonAsync<List<ResultHomeDTO>>("Homes");
            var langs = await client.GetFromJsonAsync<List<ResultLangDTO>>("Langs");
            var CreateHomeDTO = new CreateHomeDTO
            {
                HomeTranslations = langs.Select(lang => new HomeTranslationDTO
                {
                    Locale = lang.LangCode
                }).ToList()
            };
            var model = new CreateHomeViewModel
            {
                CreateHomeDTO = CreateHomeDTO,
                GetLangDTOs = langs
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateHome(CreateHomeViewModel createHomeViewModel)
        {
            CreateHomeDTO homeDto = createHomeViewModel.CreateHomeDTO;
            var client = _httpClientFactory.CreateClient("Admin");
            await client.PostAsJsonAsync<CreateHomeDTO>("Homes", homeDto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]   
        public async Task<IActionResult> UpdateHome(int id)
        {
            var client = _httpClientFactory.CreateClient("Admin");
            var langs = await client.GetFromJsonAsync<List<ResultLangDTO>>("Langs");
            var resultHomeDTO = await client.GetFromJsonAsync<UpdateHomeDTO>($"Homes/{id}");
            var model = new UpdateHomeViewModel
            {
                UpdateHomeDTO = resultHomeDTO,
                GetLangDTOs = langs
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateHome(UpdateHomeViewModel updateHomeViewModel)
        {
            UpdateHomeDTO homeDto = updateHomeViewModel.UpdateHomeDTO;
            var client = _httpClientFactory.CreateClient("Admin");
            await client.PutAsJsonAsync<UpdateHomeDTO>("Homes", homeDto);
            return RedirectToAction(nameof(Index));
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteHome(int id)
        {
            //await _client.DeleteAsync("Pages/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
}
