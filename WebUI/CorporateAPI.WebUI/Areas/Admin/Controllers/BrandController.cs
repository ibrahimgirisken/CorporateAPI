using CorporateAPI.WebUI.DTOs.Brand;
using CorporateAPI.WebUI.DTOs.Lang;
using CorporateAPI.WebUI.ViewModels.Brand;
using Microsoft.AspNetCore.Mvc;

namespace CorporateAPI.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class BrandController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BrandController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client=_httpClientFactory.CreateClient("Admin");
            var response = await client.GetAsync("Brands");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"API error: {response.StatusCode}, Reason: {response.ReasonPhrase}");
            }
            var brandDatas = await response.Content.ReadFromJsonAsync<List<ResultBrandDTO>>();
            return View(brandDatas);
        }
        [HttpGet]
        public async Task<IActionResult> CreateBrand()
        {
            var client = _httpClientFactory.CreateClient("Admin");
            var langs = await client.GetFromJsonAsync<List<ResultLangDTO>>("Langs");
            var createBrand = new CreateBrandDTO();
            var model = new CreateBrandViewModel
            {
                GetLangDTOs = langs,
                CreateBrandDTO = createBrand
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandViewModel createBrandViewModel)
        {
            CreateBrandDTO brandDto=createBrandViewModel.CreateBrandDTO;
            var client = _httpClientFactory.CreateClient("Admin");
            await client.PostAsJsonAsync<CreateBrandDTO>("Brands",brandDto);
            return RedirectToAction(nameof(Index));

        }

        [HttpGet]
        public async Task<IActionResult> UpdateBrand(int id)
        {
            var client = _httpClientFactory.CreateClient("Admin");
            var langs = await client.GetFromJsonAsync<List<ResultLangDTO>>("Langs");
            var resultBrandDTO = await client.GetFromJsonAsync<UpdateBrandDTO>($"Brands/{id}");
            var model = new UpdateBrandViewModel
            {
                GetLangDTOs = langs,
                UpdateBrandDTO = resultBrandDTO
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBrand(UpdateBrandViewModel updateBrandViewModel)
        {
            UpdateBrandDTO brandDTO=updateBrandViewModel.UpdateBrandDTO;
            var client =_httpClientFactory.CreateClient("Admin");
            await client.PutAsJsonAsync<UpdateBrandDTO>("Brands",brandDTO);
            return RedirectToAction(nameof(Index));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBrand(int id)
        {
            return RedirectToAction(nameof(Index));
        }

    }
}
