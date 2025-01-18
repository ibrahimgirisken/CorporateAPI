using CorporateAPI.WebUI.Helpers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CorporateAPI.WebUI.ViewComponents
{
    public class ApiDataComponent<T> : ViewComponent
    {
        HttpClient _client = HttpClientInstance.CreateClient();
        public async Task<IViewComponentResult> InvokeGenericAsync(string url)
        {
            var response = await _client.GetAsync(url);

            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                // 204 No Content dönerse boş bir model döndür
                return View(Activator.CreateInstance<T>());
            }

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                if (string.IsNullOrEmpty(content))
                {
                    // İçerik boşsa yine boş model döndür
                    return View(Activator.CreateInstance<T>());
                }

                var values = JsonConvert.DeserializeObject<T>(content);
                return View(values);
            }
            else
            {
                // Eğer başarısız bir API yanıtı alınırsa, boş model döndür
                return View(Activator.CreateInstance<T>());
            }
        }
    }
}
