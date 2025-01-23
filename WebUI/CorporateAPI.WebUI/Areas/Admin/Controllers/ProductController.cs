using CorporateAPI.WebUI.DTOs.Brand;
using CorporateAPI.WebUI.DTOs.Category;
using CorporateAPI.WebUI.DTOs.Lang;
using CorporateAPI.WebUI.DTOs.Product;
using CorporateAPI.WebUI.ViewModels.Product;
using Microsoft.AspNetCore.Mvc;

namespace CorporateAPI.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client=_httpClientFactory.CreateClient("Admin");
            var response = await client.GetAsync("Products?IncludeAllLanguages=true");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"API error: {response.StatusCode}, Reason: {response.ReasonPhrase}");
            }
            var productsData=await response.Content.ReadFromJsonAsync<List<ResultProductDTO>>();
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
            var model = new CreateProductViewModel
            {
                CreateProductDTO = productDto,
                GetLangDTOs = langs,
                GetCategories = categories,
                GetBrands=brands
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductViewModel createProductViewModel)
        {
            CreateProductDTO productDTO = createProductViewModel.CreateProductDTO;
            var client = _httpClientFactory.CreateClient("Admin");
            await client.PostAsJsonAsync<CreateProductDTO>("Products", productDTO);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            var client = _httpClientFactory.CreateClient("Admin");
            var langs = await client.GetFromJsonAsync<List<ResultLangDTO>>("Langs");
            var resultProductDTO = await client.GetFromJsonAsync<CreateProductDTO>($"Products/{id}");
            var model = new UpdateProductViewModel
            {
                CreateProductDTO=resultProductDTO,
                GetLangDTOs=langs
            };
            return View(model);
            return RedirectToAction(nameof(Index));

        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductViewModel updateProductViewModel)
        {
            CreateProductDTO productDto=updateProductViewModel.CreateProductDTO;
            var client = _httpClientFactory.CreateClient("Admin");
            await client.PutAsJsonAsync<CreateProductDTO>("Products",productDto);
            return RedirectToAction(nameof(Index));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            return RedirectToAction(nameof(Index));
        }
    }
}
