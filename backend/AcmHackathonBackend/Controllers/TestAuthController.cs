using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AcmHackathonBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestAuthController : ControllerBase
    {
        // This endpoint requires authentication
        [HttpGet("secure")]
        [Authorize]
        public IActionResult GetSecureData()
        {
            return Ok(new { Message = "This is a secure endpoint. You are authenticated!" });
        }

        // This endpoint does not require authentication
        [HttpGet("public")]
        public IActionResult GetPublicData()
        {
            return Ok(new { Message = "This is a public endpoint. No authentication required." });
        }
    }
} 