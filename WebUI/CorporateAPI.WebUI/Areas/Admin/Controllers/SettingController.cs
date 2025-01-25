using CorporateAPI.WebUI.DTOs.Lang;
using CorporateAPI.WebUI.DTOs.Setting;
using CorporateAPI.WebUI.ViewModels.Setting;
using Microsoft.AspNetCore.Mvc;

namespace CorporateAPI.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class SettingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SettingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient("Admin");
            var langs = await client.GetFromJsonAsync<List<ResultLangDTO>>("Langs");
            var resultSettingData = await client.GetFromJsonAsync<ResultSettingDTO>("Settings/1");
            var model = new ResultSettingViewModel
            {
                ResultSettingDTO = resultSettingData,
                GetLangDTOs = langs
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSetting(ResultSettingViewModel resultSettingViewModel)
        {
            var client = _httpClientFactory.CreateClient("Admin");
            var resultSettingDTO = resultSettingViewModel.ResultSettingDTO;
            var response = await client.PutAsJsonAsync("Settings", resultSettingDTO);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"API error: {response.StatusCode}, Reason: {response.ReasonPhrase}");
            }
            return RedirectToAction("Index");
        }
    }
}
