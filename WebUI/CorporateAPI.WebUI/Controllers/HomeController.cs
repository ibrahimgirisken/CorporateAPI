using CorporateAPI.WebUI.DTOs.Home;
using CorporateAPI.WebUI.Helpers;
using CorporateAPI.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CorporateAPI.WebUI.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
