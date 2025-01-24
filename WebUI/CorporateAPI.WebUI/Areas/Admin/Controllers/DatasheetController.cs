using CorporateAPI.WebUI.DTOs.Datasheet;
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
    }
}
