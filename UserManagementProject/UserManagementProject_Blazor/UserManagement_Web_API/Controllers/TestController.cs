using Microsoft.AspNetCore.Mvc;

namespace UserManagement_Web_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new[] { "Connected", "Blazor", "API" });
        }
    }
}
