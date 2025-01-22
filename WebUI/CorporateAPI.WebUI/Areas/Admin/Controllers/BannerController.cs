using CorporateAPI.WebUI.DTOs.Banner;
using CorporateAPI.WebUI.DTOs.Lang;
using CorporateAPI.WebUI.DTOs.Page;
using CorporateAPI.WebUI.Helpers;
using CorporateAPI.WebUI.ViewModels.Banner;
using CorporateAPI.WebUI.ViewModels.Page;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace CorporateAPI.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class BannerController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BannerController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient("Admin");
            var response = await client.GetAsync("Banners?IncludeAllLanguages=true");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"API error: {response.StatusCode}, Reason: {response.ReasonPhrase}");
            }
            var bannersData = await response.Content.ReadFromJsonAsync<List<ResultBannerDTO>>();
            return View(bannersData);
        }

        [HttpGet]
        public async Task<IActionResult> CreateBanner()
        {
            var client = _httpClientFactory.CreateClient("Admin");
            var langs = await client.GetFromJsonAsync<List<ResultLangDTO>>("Langs");
            var CreateBannerDTO = new CreateBannerDTO
            {
                BannerTranslations = langs.Select(lang => new BannerTranslationDTO
                {
                    Locale = lang.LangCode
                }).ToList()
            };
            var model = new CreateBannerViewModel
            {
                CreateBannerDTO = CreateBannerDTO,
                GetLangDTOs = langs
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBanner(CreateBannerViewModel createBannerViewModel)
        {
            CreateBannerDTO bannerDto = createBannerViewModel.CreateBannerDTO;
            var client = _httpClientFactory.CreateClient("Admin");
            await client.PostAsJsonAsync<CreateBannerDTO>("Banners", bannerDto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBanner(int id)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBanner(UpdateBannerViewModel updateBannerViewModel)
        {  
        return RedirectToAction(nameof(Index));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBanner(int id)
        {
            return RedirectToAction(nameof(Index));
        }
    }
}
