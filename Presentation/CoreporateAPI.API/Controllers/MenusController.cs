using CorporateAPI.Application.Repositories;
using CorporateAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreporateAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenusController : ControllerBase
    {
        readonly IMenuReadRepository _menuReadRepository;
public MenusController(IMenuReadRepository menuReadRepository)
        {
            _menuReadRepository = menuReadRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
           var menus= _menuReadRepository.GetAll();
            return Ok(menus);
            
        }
    }
}
