using CoreporateAPI.Infrastructure.Operations;
using CorporateAPI.WebUI.Abstract;
using CorporateAPI.WebUI.DTOs.Category;
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
        private readonly IFileService _fileService;

        public DatasheetController(IHttpClientFactory httpClientFactory, IFileService fileService)
        {
            _httpClientFactory = httpClientFactory;
            _fileService = fileService;
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
            NameOperation.ApplyCharacterRegulationToProperties(
                datasheetDto.DatasheetTranslations,
                item => item.Url ?? item.Name,
                (item, value) => item.Url = value
            );
            string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "datasheets");
            foreach (var dts in datasheetDto.DatasheetTranslations)
            {
                if (dts.DatasheetFile != null)
                {
                    dts.Path = await _fileService.SaveFileAsync(dts.DatasheetFile, uploadPath);
                }
            }

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
           
            NameOperation.ApplyCharacterRegulationToProperties(
                datasheetDto.DatasheetTranslations,
                item => item.Url ?? item.Name,
                (item, value) => item.Url = value
            );

            string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "datasheets");
            foreach (var dts in datasheetDto.DatasheetTranslations)
            {
                if (dts.DatasheetFile != null)
                {
                    dts.Path = await _fileService.UpdateFileAsync(dts.DatasheetFile, dts.Path, uploadPath);
                }
            }

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
