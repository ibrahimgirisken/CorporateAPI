using CorporateAPI.WebUI.DTOs.Module;
using CorporateAPI.WebUI.DTOs.Page;
using CorporateAPI.WebUI.Helpers;
using CorporateAPI.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CorporateAPI.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class PageController() : Controller
    {
        private readonly HttpClient _client= HttpClientInstance.CreateClient();
        public async Task<IActionResult> Index()
        {
            var response = await _client.GetFromJsonAsync<ResultPageDTO>("Pages");

            if (response == null || response.PageTranslations == null)
            {
                return View(new List<ResultPageDTO>()); // Boş bir liste döner
            }

            return View(response.PageTranslations);
        }

        public async Task<IActionResult> DeletePage(int id)
        {
            await _client.DeleteAsync("Pages/{id}");
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> CreatePage(ResultPageDTO getModuleDTO)
        {
            var modules= await _client.GetFromJsonAsync<ResultModuleDTO>("Modules");
            var viewModel = new CreatePageViewModel
            {
                GetModuleDTOs = modules,
                CreatePageDTO = new CreatePageDTO()
            };
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> CreatePage(CreatePageDTO pageDTO)
        {
            await _client.PostAsJsonAsync("Pages", pageDTO);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> UpdatePage(int id)
        {
            CreatePageDTO response= await _client.GetFromJsonAsync<CreatePageDTO>($"Pages/{id}");
            return View(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePage(UpdatePageDTO updatePageDTO)
        {
            await _client.PutAsJsonAsync("Pages", updatePageDTO);
            return RedirectToAction(nameof(Index));
        }
    }
}
