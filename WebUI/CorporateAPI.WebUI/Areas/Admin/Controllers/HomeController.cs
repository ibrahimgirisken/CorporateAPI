using CorporateAPI.WebUI.Abstract;
using CorporateAPI.WebUI.DTOs.Banner;
using CorporateAPI.WebUI.DTOs.Home;
using CorporateAPI.WebUI.DTOs.Lang;
using CorporateAPI.WebUI.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;

namespace CorporateAPI.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IFileService _fileService;
        public HomeController(IHttpClientFactory httpClientFactory, IFileService fileService)
        {
            _httpClientFactory = httpClientFactory;
            _fileService = fileService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient("Admin");
            var response = await client.GetAsync("Homes?IncludeAllLanguages=true");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"API error: {response.StatusCode}, Reason: {response.ReasonPhrase}");
            }
            var homesData = await response.Content.ReadFromJsonAsync<List<ResultHomeDTO>>();
            return View(homesData);
        }

        [HttpGet]

        public async Task<IActionResult> CreateHome()
        {
            var client = _httpClientFactory.CreateClient("Admin");
            var homes = await client.GetFromJsonAsync<List<ResultHomeDTO>>("Homes");
            var langs = await client.GetFromJsonAsync<List<ResultLangDTO>>("Langs");
            var CreateHomeDTO = new CreateHomeDTO
            {
                HomeTranslations = langs.Select(lang => new HomeTranslationDTO
                {
                    Locale = lang.LangCode
                }).ToList()
            };
            var model = new CreateHomeViewModel
            {
                CreateHomeDTO = CreateHomeDTO,
                GetLangDTOs = langs
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateHome(CreateHomeViewModel createHomeViewModel)
        {
            CreateHomeDTO homeDto = createHomeViewModel.CreateHomeDTO;

            string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "homes");

            // Dosyaları kaydet
            homeDto.Image1 = await _fileService.SaveFileAsync(homeDto.Image1File, uploadPath);
            homeDto.Image2 = await _fileService.SaveFileAsync(homeDto.Image2File, uploadPath);
            homeDto.Image3 = await _fileService.SaveFileAsync(homeDto.Image3File, uploadPath);
            homeDto.Image4 = await _fileService.SaveFileAsync(homeDto.Image4File, uploadPath);
            homeDto.Image5 = await _fileService.SaveFileAsync(homeDto.Image5File, uploadPath);
            homeDto.Video = await _fileService.SaveFileAsync(homeDto.VideoFile, uploadPath);

            var client = _httpClientFactory.CreateClient("Admin");
            await client.PostAsJsonAsync<CreateHomeDTO>("Homes", homeDto);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]   
        public async Task<IActionResult> UpdateHome(int id)
        {
            var client = _httpClientFactory.CreateClient("Admin");
            var langs = await client.GetFromJsonAsync<List<ResultLangDTO>>("Langs");
            var resultHomeDTO = await client.GetFromJsonAsync<UpdateHomeDTO>($"Homes/{id}");
            var model = new UpdateHomeViewModel
            {
                UpdateHomeDTO = resultHomeDTO,
                GetLangDTOs = langs
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateHome(UpdateHomeViewModel updateHomeViewModel)
        {
            UpdateHomeDTO homeDto = updateHomeViewModel.UpdateHomeDTO;
            var client = _httpClientFactory.CreateClient("Admin");

            string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "homes");

            homeDto.Image1 = await _fileService.UpdateFileAsync(homeDto.Image1File, homeDto.Image1, uploadPath);
            homeDto.Image2   = await _fileService.UpdateFileAsync(homeDto.Image2File, homeDto.Image2, uploadPath);
            homeDto.Image3 = await _fileService.UpdateFileAsync(homeDto.Image3File, homeDto.Image3, uploadPath);
            homeDto.Image4 = await _fileService.UpdateFileAsync(homeDto.Image4File, homeDto.Image4, uploadPath);
            homeDto.Image5 = await _fileService.UpdateFileAsync(homeDto.Image5File, homeDto.Image5, uploadPath);
            homeDto.Video = await _fileService.UpdateFileAsync(homeDto.VideoFile, homeDto.Video, uploadPath);

            await client.PutAsJsonAsync<UpdateHomeDTO>("Homes", homeDto);
            return RedirectToAction(nameof(Index));
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteHome(int id)
        {
            //await _client.DeleteAsync("Pages/{id}");
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Images()
        {
            string imagesPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "homes");
            var files = Directory.GetFiles(imagesPath)
                                 .Where(file => file.EndsWith(".jpg") || file.EndsWith(".png") || file.EndsWith(".gif") || file.EndsWith(".webp"))
                                 .Select(file => new
                                 {
                                     Url = "/uploads/homes/" + Path.GetFileName(file),
                                     Thumbnail = "/uploads/homes/thumbnails/" + Path.GetFileName(file)
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
                    string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "homes");
                    string filePath = await _fileService.SaveFileAsync(upload, uploadPath);
                    string fileUrl = Url.Content($"~/uploads/homes/{filePath}");
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
