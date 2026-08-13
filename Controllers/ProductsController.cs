using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecureApi.Data;
using SecureApi.Models;

namespace SecureApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("search")]
        [Authorize]
        public async Task<IActionResult> Search(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return BadRequest("Product name is required.");
            }

            if (name.Length > 100)
            {
                return BadRequest("Search term is too long.");
            }

            var products = await _context.Products
                .Where(p => p.Name.Contains(name))
                .ToListAsync();

            return Ok(products);
        }
    }
}