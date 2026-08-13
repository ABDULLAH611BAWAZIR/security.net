using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SecureApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SecureController : ControllerBase
    {
        [HttpGet("profile")]
        [Authorize]
        public IActionResult GetProfile()
        {
            return Ok(new
            {
                Message = "You are authenticated.",
                Username = User.Identity?.Name,
                Role = User.FindFirst("role")?.Value
            });
        }

        [HttpGet("admin")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAdminData()
        {
            return Ok(new
            {
                Message = "Only administrators can access this endpoint."
            });
        }
    }
}