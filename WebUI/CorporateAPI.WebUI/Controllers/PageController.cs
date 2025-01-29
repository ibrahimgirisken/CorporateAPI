using CorporateAPI.WebUI.DTOs.Page;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace CorporateAPI.WebUI.Controllers
{
    public class PageController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public PageController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet("{language}/{*urlAddress}")]
        public async Task<IActionResult> GetByLanguageAndUrl(string language, string urlAddress)
        {
            language = RouteData.Values["language"]?.ToString() ?? CultureInfo.CurrentUICulture.Name;
            var client = _httpClientFactory.CreateClient("Admin");
            client.DefaultRequestHeaders.Add("Accept-Language", language);



            var apiUrl = $"Pages/Page/{urlAddress}?language={language}";
            var response=await client.GetAsync(apiUrl);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"API error: {response.StatusCode}, Reason: {response.ReasonPhrase}");
            }

            var values = await response.Content.ReadFromJsonAsync<ResultPageDTO>();
            var data = values;
            return View(values);
        }

    }
}
