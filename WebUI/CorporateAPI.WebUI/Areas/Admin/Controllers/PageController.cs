using CoreporateAPI.Infrastructure.Operations;
using CorporateAPI.WebUI.Abstract;
using CorporateAPI.WebUI.DTOs.Lang;
using CorporateAPI.WebUI.DTOs.Module;
using CorporateAPI.WebUI.DTOs.Page;
using CorporateAPI.WebUI.ViewModels.Page;
using Microsoft.AspNetCore.Mvc;

namespace CorporateAPI.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class PageController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IFileService _fileService;
        public PageController(IHttpClientFactory httpClientFactory, IFileService fileService)
        {
            _httpClientFactory = httpClientFactory;
            _fileService = fileService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient("Admin");
            var response = await client.GetAsync("Pages?IncludeAllLanguages=true");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"API error: {response.StatusCode}, Reason: {response.ReasonPhrase}");
            }
            var pagesData = await response.Content.ReadFromJsonAsync<List<ResultPageDTO>>();
            return View(pagesData);
        }
        [HttpGet]
        public async Task<IActionResult> CreatePage()
        {
            var client = _httpClientFactory.CreateClient("Admin");
            var modules = await client.GetFromJsonAsync<List<ResultModuleDTO>>("Modules");
            var langs = await client.GetFromJsonAsync<List<ResultLangDTO>>("Langs");
            var CreatePageDTO = new CreatePageDTO
            {
                PageTranslations = langs.Select(lang => new PageTranslationDTO
                {
                    Locale = lang.LangCode 
                }).ToList()
            };
            var model = new CreatePageViewModel
            {
                CreatePageDTO = CreatePageDTO,
                GetLangDTOs = langs,
                GetModuleDTOs = modules
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> CreatePage(CreatePageViewModel createPageViewModel)
        {
            CreatePageDTO pageDto = createPageViewModel.CreatePageDTO;
            NameOperation.ApplyCharacterRegulationToProperties(
                pageDto.PageTranslations,
                item => item.Url ?? item.Title,
                (item, value) => item.Url = value
            );


            string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "pages");

            // Dosyaları kaydet
            pageDto.Image1 = await _fileService.SaveFileAsync(pageDto.Image1File, uploadPath);
            pageDto.Image2 = await _fileService.SaveFileAsync(pageDto.Image2File, uploadPath);
            pageDto.Image3 = await _fileService.SaveFileAsync(pageDto.Image3File, uploadPath);
            pageDto.Video = await _fileService.SaveFileAsync(pageDto.VideoFile, uploadPath);


            var client = _httpClientFactory.CreateClient("Admin");
            await client.PostAsJsonAsync<CreatePageDTO>("Pages", pageDto);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> UpdatePage(int id)
        {
            var client = _httpClientFactory.CreateClient("Admin");
            var modules = await client.GetFromJsonAsync<List<ResultModuleDTO>>("Modules");
            var langs = await client.GetFromJsonAsync<List<ResultLangDTO>>("Langs");
            var resultPageDTO = await client.GetFromJsonAsync<UpdatePageDTO>($"Pages/{id}");
            var model = new UpdatePageViewModel
            {
                UpdatePageDTO = resultPageDTO,
                GetLangDTOs = langs,
                GetModuleDTOs = modules
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePage(UpdatePageViewModel updatePageViewModel)
        {
            UpdatePageDTO pageDto = updatePageViewModel.UpdatePageDTO;
            NameOperation.ApplyCharacterRegulationToProperties(
                pageDto.PageTranslations,
                item => item.Url ?? item.Title,
                (item, value) => item.Url = value
            );

            string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "pages");

            // Dosyaları kaydet
            pageDto.Image1 = await _fileService.SaveFileAsync(pageDto.Image1File, uploadPath);
            pageDto.Image2 = await _fileService.SaveFileAsync(pageDto.Image2File, uploadPath);
            pageDto.Image3 = await _fileService.SaveFileAsync(pageDto.Image3File, uploadPath);
            pageDto.Video = await _fileService.SaveFileAsync(pageDto.VideoFile, uploadPath);

            var client = _httpClientFactory.CreateClient("Admin");
            await client.PutAsJsonAsync<UpdatePageDTO>("Pages", pageDto);
            return RedirectToAction(nameof(Index));
        }
        [HttpDelete]
        public async Task<IActionResult> DeletePage(int id)
        {
            //await _client.DeleteAsync("Pages/{id}");
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Images()
        {
            string imagesPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "pages");
            var files = Directory.GetFiles(imagesPath)
                                 .Where(file => file.EndsWith(".jpg") || file.EndsWith(".png") || file.EndsWith(".gif") || file.EndsWith(".webp"))
                                 .Select(file => new
                                 {
                                     Url = "/uploads/pages/" + Path.GetFileName(file),
                                     Thumbnail = "/uploads/pages/thumbnails/" + Path.GetFileName(file)
                                 })
                                 .ToList();

            return Json(files);
        }


        [HttpPost]
        public async Task<IActionResult> UploadImage(IFormFile upload, string CKEditorFuncNum)
        {
            if (upload != null && upload.Length > 0)
            {
                try
                {
                    string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "pages");
                    string filePath = await _fileService.SaveFileAsync(upload, uploadPath);
                    string fileUrl = Url.Content($"~/uploads/pages/{filePath}");
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
