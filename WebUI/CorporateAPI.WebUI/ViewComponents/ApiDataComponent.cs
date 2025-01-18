using CorporateAPI.WebUI.Helpers;
using CorporateAPI.WebUI.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Globalization;
using System.Net;

namespace CorporateAPI.WebUI.ViewComponents
{
    public class ApiDataComponent<T> : ViewComponent
    {
        protected readonly IHttpClientFactory _httpClientFactory;
        public ApiDataComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeGenericAsync<T>(string endpoint) where T : class
        {
            var language = RouteData.Values["language"]?.ToString() ?? CultureInfo.CurrentUICulture.Name;
            var client = _httpClientFactory.CreateClient("Admin");
            client.DefaultRequestHeaders.Add("Accept-Language", language);

            var response = await client.GetAsync(endpoint);

            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                return View(default(T));
            }

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"API error: {response.StatusCode}, Reason: {response.ReasonPhrase}");
            }
            try
            {
                var result = await response.Content.ReadFromJsonAsync<T>();
                return View(result ?? default(T));             }
            catch (JsonException ex)
            {
                throw new Exception("Error deserializing JSON response.", ex);
            }
        }
    }
}
