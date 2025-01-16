using CorporateAPI.WebUI.DTOs.Banner;
using CorporateAPI.WebUI.DTOs.Lang;
using CorporateAPI.WebUI.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace CorporateAPI.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class BannerController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultBannerDTO>>("banners");
            if (values == null)
            {
                return View(new List<ResultBannerDTO>());
            }
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> CreateBanner()
        {
            var langs = await _client.GetFromJsonAsync<List<ResultLangDTO>>("Langs");
            var model = new CreateBannerDTO
            {
                BannerTranslations = langs.Select(lang => new BannerTranslationDTO { Locale = lang.LangCode }).ToList()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBanner(CreateBannerDTO bannerDTO)
        {
            await _client.PostAsJsonAsync("Banners", bannerDTO);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBanner(int id)
        {
            var value = await _client.GetFromJsonAsync<ResultBannerDTO>($"banners/{id}");
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBanner(UpdateBannerDTO updateBannerDTO)
        {
            await _client.PutAsJsonAsync("banners", updateBannerDTO);
            return RedirectToAction(nameof(Index));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBanner(int id)
        {
            await _client.DeleteAsync($"banners/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
}
