using CorporateAPI.WebUI.Abstract;
using CorporateAPI.WebUI.DTOs.Banner;
using CorporateAPI.WebUI.DTOs.Lang;
using CorporateAPI.WebUI.ViewModels.Banner;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
            var createBannerDto = createBannerViewModel.CreateBannerDTO;

            string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "banners");
            createBannerDto.DesktopImage = await _fileService.SaveFileAsync(createBannerDto.DesktopImageFile, uploadPath);
            createBannerDto.TableteImage = await _fileService.SaveFileAsync(createBannerDto.TableteImageFile, uploadPath);
            createBannerDto.MobileImage = await _fileService.SaveFileAsync(createBannerDto.MobileImageFile, uploadPath);
            createBannerDto.DesktopVideo = await _fileService.SaveFileAsync(createBannerDto.DesktopVideoFile, uploadPath);
            createBannerDto.MobileVideo = await _fileService.SaveFileAsync(createBannerDto.MobileVideoFile, uploadPath);

            var client = _httpClientFactory.CreateClient("Admin");
            await client.PostAsJsonAsync("Banners", createBannerDto);

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
            UpdateBannerDTO updateBannerDto = updateBannerViewModel.UpdateBannerDTO;
            string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "banners");

            updateBannerDto.DesktopImage = await _fileService.UpdateFileAsync(updateBannerDto.DesktopImageFile, updateBannerDto.DesktopImage, uploadPath);
            updateBannerDto.TableteImage = await _fileService.UpdateFileAsync(updateBannerDto.TableteImageFile, updateBannerDto.TableteImage, uploadPath);
            updateBannerDto.MobileImage = await _fileService.UpdateFileAsync(updateBannerDto.MobileImageFile, updateBannerDto.MobileImage, uploadPath);
            updateBannerDto.DesktopVideo = await _fileService.UpdateFileAsync(updateBannerDto.DesktopVideoFile, updateBannerDto.DesktopVideo, uploadPath);
            updateBannerDto.MobileVideo = await _fileService.UpdateFileAsync(updateBannerDto.MobileVideoFile, updateBannerDto.MobileVideo, uploadPath);

            var client = _httpClientFactory.CreateClient("Admin");
            await client.PutAsJsonAsync<UpdateBannerDTO>("Banners", updateBannerDto);
            return RedirectToAction(nameof(Index));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBanner(int id)
        {
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Images()
        {
            string imagesPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "banners");
            var files = Directory.GetFiles(imagesPath)
                                 .Where(file => file.EndsWith(".jpg") || file.EndsWith(".png") || file.EndsWith(".gif") || file.EndsWith(".webp"))
                                 .Select(file => new
                                 {
                                     Url = "/uploads/banners/" + Path.GetFileName(file),
                                     Thumbnail = "/uploads/banners/thumbnails/" + Path.GetFileName(file)
                                 })
                                 .ToList();

            return Json(files);
        }


        [HttpPost]
        public async Task<IActionResult> UploadProductImage(IFormFile upload, string CKEditorFuncNum)
        {
            if (upload != null && upload.Length > 0)
            {
                try
                {
                    string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "banners");
                    string filePath = await _fileService.SaveFileAsync(upload, uploadPath);
                    string fileUrl = Url.Content($"~/uploads/banners/{filePath}");
                    string script = $"<script>window.parent.CKEDITOR.tools.callFunction({CKEditorFuncNum}, '{fileUrl}');</script>";
                    return Content(script, "text/html");
                }
                catch (Exception ex)
                {
                    return Json(new { uploaded = false, error = new { message = ex.Message } });
                }
            }
            return Json(new { uploaded = false, error = new { message = "Dosya yüklenemedi." } });
        }
    }
}
