using CoreporateAPI.Infrastructure.Operations;
using CorporateAPI.WebUI.Abstract;
using CorporateAPI.WebUI.DTOs.Brand;
using CorporateAPI.WebUI.DTOs.Category;
using CorporateAPI.WebUI.DTOs.Lang;
using CorporateAPI.WebUI.DTOs.Product;
using CorporateAPI.WebUI.ViewModels.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SixLabors.ImageSharp;

namespace CorporateAPI.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IFileService _fileService;
        private readonly IWebHostEnvironment _env;
        public ProductController(IHttpClientFactory httpClientFactory, IFileService fileService, IWebHostEnvironment env)
        {
            _httpClientFactory = httpClientFactory;
            _fileService = fileService;
            _env = env;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient("Admin");
            var response = await client.GetAsync("Products?IncludeAllLanguages=true");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"API error: {response.StatusCode}, Reason: {response.ReasonPhrase}");
            }
            var productsData = await response.Content.ReadFromJsonAsync<List<ResultProductDTO>>();
            return View(productsData);
        }
        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            var client = _httpClientFactory.CreateClient("Admin");
            var langs = await client.GetFromJsonAsync<List<ResultLangDTO>>("Langs");
            var categories = await client.GetFromJsonAsync<List<ResultCategoryDTO>>("Categories?IncludeAllLanguges=true");
            var brands = await client.GetFromJsonAsync<List<ResultBrandDTO>>("Brands?IncludeAllLanguges=true");
            var productDto = new CreateProductDTO
            {
                ProductTranslations = langs.Select(lang => new ProductTranslationDTO
                {
                    Locale = lang.LangCode
                }).ToList(),
            };
            var selectedBrand = new SelectList(brands.Select(b => new {b.Id,b.Name}),"Id", "Name");
            var selectedCategory=new SelectList(categories.Select(c => new {c.Id,Name=c.CategoryTranslations.FirstOrDefault(t=>t.Locale=="en")?.Name}),"Id", "Name");
            var model = new CreateProductViewModel
            {
                CreateProductDTO = productDto,
                GetLangDTOs = langs,
                GetCategories = selectedCategory,
                GetBrands = selectedBrand
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductViewModel createProductViewModel)
        {
            CreateProductDTO productDTO = createProductViewModel.CreateProductDTO;
            NameOperation.ApplyCharacterRegulationToProperties(
                     productDTO.ProductTranslations,
                     item => item.Url ?? item.Title,
                     (item, value) => item.Url = value
                 );
            string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "products");

            // Dosyaları kaydet
            productDTO.Image1 = await _fileService.SaveFileAsync(productDTO.Image1File, uploadPath);
            productDTO.Image2 = await _fileService.SaveFileAsync(productDTO.Image2File, uploadPath);
            productDTO.Image3 = await _fileService.SaveFileAsync(productDTO.Image3File, uploadPath);
            productDTO.Image4 = await _fileService.SaveFileAsync(productDTO.Image4File, uploadPath);
            productDTO.Image5 = await _fileService.SaveFileAsync(productDTO.Image5File, uploadPath);
            productDTO.Video = await _fileService.SaveFileAsync(productDTO.VideoFile, uploadPath);

            var client = _httpClientFactory.CreateClient("Admin");
            await client.PostAsJsonAsync<CreateProductDTO>("Products", productDTO);
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            var client = _httpClientFactory.CreateClient("Admin");
            var langs = await client.GetFromJsonAsync<List<ResultLangDTO>>("Langs");
            var categories = await client.GetFromJsonAsync<List<ResultCategoryDTO>>("Categories?IncludeAllLanguges=true");
            var brands = await client.GetFromJsonAsync<List<ResultBrandDTO>>("Brands?IncludeAllLanguges=true");
            var resultProductDTO = await client.GetFromJsonAsync<UpdateProductDTO>($"Products/{id}");
            var selectedCategory = new SelectList(categories.Select(c => new { c.Id, Name = c.CategoryTranslations.FirstOrDefault(t => t.Locale == "en")?.Name }), "Id", "Name");
            var selectedBrand = new SelectList(brands.Select(b => new { b.Id, b.Name }), "Id", "Name");
            var model = new UpdateProductViewModel
            {
                UpdateProductDTO = resultProductDTO,
                GetLangDTOs = langs,
                GetBrands = selectedBrand,
                GetCategories = selectedCategory
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductViewModel updateProductViewModel)
        {
            UpdateProductDTO updateProductDto = updateProductViewModel.UpdateProductDTO;
            NameOperation.ApplyCharacterRegulationToProperties(
                 updateProductDto.ProductTranslations,
                 item => item.Url ?? item.Title,
                 (item, value) => item.Url = value
             );
            string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "products");

            updateProductDto.Image1 = await _fileService.UpdateFileAsync(updateProductDto.Image1File, updateProductDto.Image1, uploadPath);
            updateProductDto.Image2 = await _fileService.UpdateFileAsync(updateProductDto.Image2File, updateProductDto.Image2, uploadPath);
            updateProductDto.Image3 = await _fileService.UpdateFileAsync(updateProductDto.Image3File, updateProductDto.Image3, uploadPath);
            updateProductDto.Image4 = await _fileService.UpdateFileAsync(updateProductDto.Image4File, updateProductDto.Image4, uploadPath);
            updateProductDto.Image5 = await _fileService.UpdateFileAsync(updateProductDto.Image5File, updateProductDto.Image5, uploadPath);

            var client = _httpClientFactory.CreateClient("Admin");
            await client.PutAsJsonAsync<UpdateProductDTO>("Products", updateProductDto);
            return RedirectToAction(nameof(Index));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Images()
        {
            string imagesPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "products");
            var files = Directory.GetFiles(imagesPath)
                                 .Where(file => file.EndsWith(".jpg") || file.EndsWith(".png") || file.EndsWith(".gif") || file.EndsWith(".webp"))
                                 .Select(file => new
                                 {
                                     Url = "/uploads/products/" + Path.GetFileName(file),
                                     Thumbnail = "/uploads/products/thumbnails/" + Path.GetFileName(file)
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
                    string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "products");
                    string filePath = await _fileService.SaveFileAsync(upload, uploadPath);
                    string fileUrl = Url.Content($"~/uploads/products/{filePath}");
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
