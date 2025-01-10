using CorporateAPI.Domain.Entities.Banner;
using CorporateAPI.WebUI.DTOs.Banner;
using CorporateAPI.WebUI.DTOs.Lang;
using CorporateAPI.WebUI.Helpers;
using CorporateAPI.WebUI.ViewModels;
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
            var langs=await _client.GetFromJsonAsync<List<ResultLangDTO>>("langs");
            var model = new CreateBannerViewModel
            {
                CreateBannerDTO = new CreateBannerDTO(),
                Langs = langs,
                BannerTranslations = new List<BannerTranslationDTO>() // Boş listeyle başlatılıyor
    };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBanner(CreateBannerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                // Eğer model doğrulama başarısızsa, form tekrar gösterilir
                return View(model);
            }

            // CreateBannerDTO ve BannerTranslations'ı kullanarak API'ye gönderim
            var createBannerDTO = model.CreateBannerDTO;
            createBannerDTO.BannerTranslations = model.BannerTranslations;

            var response = await _client.PostAsJsonAsync("banners", createBannerDTO);

            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError("", "An error occurred while creating the banner.");
                return View(model);
            }

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
