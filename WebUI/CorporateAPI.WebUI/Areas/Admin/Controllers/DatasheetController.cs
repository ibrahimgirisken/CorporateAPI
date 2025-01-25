using CorporateAPI.WebUI.DTOs.Datasheet;
using CorporateAPI.WebUI.DTOs.Lang;
using CorporateAPI.WebUI.ViewModels.Datasheet;
using Microsoft.AspNetCore.Mvc;

namespace CorporateAPI.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class DatasheetController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DatasheetController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client=_httpClientFactory.CreateClient("Admin");
            var response = await client.GetAsync("Datasheets?IncludeAllLanguages=true");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"API error: {response.StatusCode}, Reason: {response.ReasonPhrase}");
            }
            var datasheetsData = await response.Content.ReadFromJsonAsync<List<ResultDatasheetDTO>>();
            return View(datasheetsData);
        }
        [HttpGet]
        public async Task<IActionResult> CreateDatasheet()
        {
            var client = _httpClientFactory.CreateClient("Admin");
            var langs = await client.GetFromJsonAsync<List<ResultLangDTO>>("Langs");
            var createDatasheetDTO = new CreateDatasheetDTO
            {
                DatasheetTranslations = langs.Select(lang => new DatasheetTranslationDTO
                {
                    Locale=lang.LangCode,
                }).ToList(),
            };
            var model = new CreateDatasheetViewModel
            {
                CreateDatasheetDTO = createDatasheetDTO,
                GetLangDTOs=langs
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDatasheet(CreateDatasheetViewModel createDatasheetViewModel)
        {
            CreateDatasheetDTO datasheetDto = createDatasheetViewModel.CreateDatasheetDTO;
            var client = _httpClientFactory.CreateClient("Admin");
            await client.PostAsJsonAsync<CreateDatasheetDTO>("Datasheets", datasheetDto);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> UpdateDatasheet(int id)
        {
            var client = _httpClientFactory.CreateClient("Admin");
            var langs = await client.GetFromJsonAsync<List<ResultLangDTO>>("Langs");
            var resultDatasheetDTO = await client.GetFromJsonAsync<UpdateDatasheetDTO>($"Datasheets/{id}");

            var model = new UpdateDatasheetViewModel
            {
                UpdateDatasheetDTO = resultDatasheetDTO,
                GetLangDTOs = langs
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDatasheet(UpdateDatasheetViewModel updateDatasheetViewModel)
        {
            UpdateDatasheetDTO datasheetDto = updateDatasheetViewModel.UpdateDatasheetDTO;
            var client = _httpClientFactory.CreateClient("Admin");
            await client.PutAsJsonAsync<UpdateDatasheetDTO>("Datasheets", datasheetDto);
            return RedirectToAction(nameof(Index));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDatasheet(int id)
        {
            var client = _httpClientFactory.CreateClient("Admin");
            await client.DeleteAsync($"Datasheets/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
}
