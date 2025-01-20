using CorporateAPI.WebUI.DTOs.Lang;
using CorporateAPI.WebUI.DTOs.Menu;
using CorporateAPI.WebUI.ViewModels.Menu;
using Microsoft.AspNetCore.Mvc;

namespace CorporateAPI.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class MenuController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MenuController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient("Admin");
            var response= await client.GetAsync("Menus?IncludeAllLanguages=true");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"API error: {response.StatusCode}, Reason: {response.ReasonPhrase}");
            }
            var menuData = await response.Content.ReadFromJsonAsync<List<ResultMenuDTO>>();
            return View(menuData);
        }

        [HttpGet]
        public async Task<IActionResult> CreateMenu()
        {
            var client = _httpClientFactory.CreateClient("Admin");
            var langs = await client.GetFromJsonAsync<List<ResultLangDTO>>("Langs");
            var menus = await client.GetFromJsonAsync<List<ResultMenuDTO>>("Menus?IncludeAllLanguages=true");
            var createMenuDTO = new CreateMenuDTO
            {
                MenuTranslations = langs.Select(lang => new MenuTranslationDTO
                {
                    Locale = lang.LangCode
                }).ToList()
            };
            var model = new CreateMenuViewModel
            {
                CreateMenuDTO = createMenuDTO,
                GetLangDTOs = langs,
                ResultMenus=menus
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> CreateMenu(CreateMenuViewModel createMenuViewModel)
        {
            CreateMenuDTO menuDto = createMenuViewModel.CreateMenuDTO;
            var client = _httpClientFactory.CreateClient("Admin");
            await client.PostAsJsonAsync<CreateMenuDTO>("Menus", menuDto);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> UpdateMenu(int id)
        {
            var client = _httpClientFactory.CreateClient("Admin");
            var langs = await client.GetFromJsonAsync<List<ResultLangDTO>>("Langs");
            var menus = await client.GetFromJsonAsync<List<ResultMenuDTO>>("Menus?IncludeAllLanguages=true");
            var resultMenuDTO = await client.GetFromJsonAsync<UpdateMenuDTO>($"Menus/{id}");
            var model = new UpdateMenuViewModel
            {
                UpdateMenuDTO = resultMenuDTO,
                GetLangDTOs = langs,
                ResultMenus=menus
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateMenu(UpdateMenuViewModel updateMenuViewModel)
        {
            UpdateMenuDTO menuDto = updateMenuViewModel.UpdateMenuDTO;
            var client = _httpClientFactory.CreateClient("Admin");
            await client.PutAsJsonAsync<UpdateMenuDTO>("Menus", menuDto);
            return RedirectToAction(nameof(Index));
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteMenu(int id)
        {
            //await _client.DeleteAsync("Pages/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
}
