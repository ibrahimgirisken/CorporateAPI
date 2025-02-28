using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreporateAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class RolesController : ControllerBase
    {

        [HttpGet("{id}")]
        public IActionResult GetRole(string id)
        {
            return Ok("Role");
        }
        [HttpGet]
        public IActionResult GetRoles()
        {
            return Ok("Roles");
        }

        [HttpPost]
        public IActionResult CreateRole()
        {
            return Ok("Role");
        }
        [HttpPut("{Id}")]
        public IActionResult UpdateRole()
        {
            return Ok("Role");
        }
        [HttpDelete("{name}")]
        public IActionResult DeleteRole(int id)
        {
            return Ok("Role");
        }
    }
}
