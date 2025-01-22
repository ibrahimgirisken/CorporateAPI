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
            var model = new CreateProductDTO
            {
                ProductTranslations = langs.Select(lang => new ProductTranslationDTO
                {
                    Locale = lang.LangCode
                }).ToList(),
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
            var resultProductDTO = await client.GetFromJsonAsync<UpdateProductDTO>($"Products/{id}");
            var model = new UpdateProductViewModel
            {
                UpdateProductDTO=resultProductDTO,
                GetLangDTOs=langs
            };
            return View(model);
            return RedirectToAction(nameof(Index));

        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductViewModel updateProductViewModel)
        {
            UpdateProductDTO productDto=updateProductViewModel.UpdateProductDTO;
            var client = _httpClientFactory.CreateClient("Admin");
            await client.PutAsJsonAsync<UpdateProductDTO>("Products",productDto);
            return RedirectToAction(nameof(Index));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            return RedirectToAction(nameof(Index));
        }
    }
}
