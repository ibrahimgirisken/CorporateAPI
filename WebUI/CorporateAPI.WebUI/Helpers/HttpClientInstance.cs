using CorporateAPI.WebUI.Services.Abstract;
using Microsoft.AspNetCore.Http;
using System.Net.Http;

namespace CorporateAPI.WebUI.Helpers
{
    public static class HttpClientInstance
    {
        public static HttpClient CreateClient(HttpContext httpContext)
        {
            var language = httpContext.Request.Headers["Accept-Language"].ToString();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7272/api/");
            client.DefaultRequestHeaders.Add("Accept-Language", "de");
            return client;
        }

    }
}
