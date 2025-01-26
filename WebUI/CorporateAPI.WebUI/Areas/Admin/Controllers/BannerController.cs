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
            var bannerDto = createBannerViewModel.CreateBannerDTO;
            string subDirectory = "banners";

            var desktopImage = Request.Form.Files.FirstOrDefault(f => f.Name == "DesktopImage");
            if (desktopImage != null)
            {
                bannerDto.DesktopImage = await _fileService.SaveFileAsync(desktopImage, subDirectory);
            }

            var tabletImage = Request.Form.Files.FirstOrDefault(f => f.Name == "TableteImage");
            if (tabletImage != null)
            {
                bannerDto.TableteImage = await _fileService.SaveFileAsync(tabletImage, subDirectory);
            }

            var mobileImage = Request.Form.Files.FirstOrDefault(f => f.Name == "MobileImage");
            if (mobileImage != null)
            {
                bannerDto.MobileImage = await _fileService.SaveFileAsync(mobileImage, subDirectory);
            }

            // API'ye post işlemi
            var client = _httpClientFactory.CreateClient("Admin");
            await client.PostAsJsonAsync("Banners", bannerDto);

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
            UpdateBannerDTO bannerDto = updateBannerViewModel.UpdateBannerDTO;
            var client = _httpClientFactory.CreateClient("Admin");

            string subDirectory = "banners";
            string oldDesktopImage = Request.Form["OldDesktopImage"];
            string oldTabletImage = Request.Form["OldTableteImage"];
            string oldMobileImage = Request.Form["OldMobileImage"];

            // Desktop Image güncelleme
            var desktopImage = Request.Form.Files.FirstOrDefault(f => f.Name == "DesktopImage");
            if (desktopImage != null)
            {
                bannerDto.DesktopImage = await _fileService.UpdateFileAsync(oldDesktopImage, desktopImage, subDirectory);
            }

            // Tablet Image güncelleme
            var tabletImage = Request.Form.Files.FirstOrDefault(f => f.Name == "TableteImage");
            if (tabletImage != null)
            {
                bannerDto.TableteImage = await _fileService.UpdateFileAsync(oldTabletImage, tabletImage, subDirectory);
            }

            // Mobile Image güncelleme
            var mobileImage = Request.Form.Files.FirstOrDefault(f => f.Name == "MobileImage");
            if (mobileImage != null)
            {
                bannerDto.MobileImage = await _fileService.UpdateFileAsync(oldMobileImage, mobileImage, subDirectory);
            }

            // API'ye post işlemi


            await client.PutAsJsonAsync<UpdateBannerDTO>("Banners", bannerDto);
            return RedirectToAction(nameof(Index));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBanner(int id)
        {
            return RedirectToAction(nameof(Index));
        }
    }
}
