using CorporateAPI.WebUI.Abstract;
using CorporateAPI.WebUI.DTOs.Banner;
using CorporateAPI.WebUI.DTOs.Lang;
using CorporateAPI.WebUI.ViewModels.Banner;
using Microsoft.AspNetCore.Mvc;

namespace CorporateAPI.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class BannerController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IFileService _fileService;
        public BannerController(IHttpClientFactory httpClientFactory, IFileService fileService)
        {
            _httpClientFactory = httpClientFactory;
            _fileService = fileService;
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
            var client = _httpClientFactory.CreateClient("Admin");
            var langs = await client.GetFromJsonAsync<List<ResultLangDTO>>("Langs");
            var resultBannerDTO = await client.GetFromJsonAsync<UpdateBannerDTO>($"Banners/{id}");
            var model = new UpdateBannerViewModel
            {
                GetLangDTOs = langs,
                UpdateBannerDTO = resultBannerDTO
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBanner(UpdateBannerViewModel updateBannerViewModel)
        {
            UpdateBannerDTO updateBannerDTO = updateBannerViewModel.UpdateBannerDTO;
            var client = _httpClientFactory.CreateClient("Admin");
            await client.PutAsJsonAsync<UpdateBannerDTO>("Banners", updateBannerDTO);
            return RedirectToAction(nameof(Index));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBanner(int id)
        {
            return RedirectToAction(nameof(Index));
        }
    }
}
