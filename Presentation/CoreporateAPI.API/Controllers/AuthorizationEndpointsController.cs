using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreporateAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationEndpointsController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> AssignRoleEndpoint()
        {
            return null;
        }
    }
}
