using CorporateAPI.WebUI.DTOs.Module;
using Microsoft.AspNetCore.Mvc;

namespace CorporateAPI.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class ModuleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> DeleteModule()
        {
            return null;
        }

        public IActionResult CreateModule()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateModule(CreateModuleDTO moduleDTO)
        {
            return null;
        }

        public IActionResult UpdateModule()
        {
            return null;
        }

        [HttpPost]
        public async Task<IActionResult> UpdateModule(UpdateModuleDTO updateModuleDTO)
        {
            return null;
        }
    }
}
