using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnionSample.Application.DTOs;
using OnionSample.Application.Interfaces;
using System.Threading.Tasks;

namespace OnionSample.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductAppService _productAppService;
        public ProductsController(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }

        // Customer: Read operations (public access)
        [HttpGet("all")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productAppService.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productAppService.GetByIdAsync(id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        // Admin: Create, update, and delete operations.
        [HttpPost("admin/create")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] ProductDto productDto)
        {
            var created = await _productAppService.CreateAsync(productDto);
            return Ok(created);
        }

        [HttpPut("admin/update")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update([FromBody] ProductDto productDto)
        {
            await _productAppService.UpdateAsync(productDto);
            return Ok("Product updated successfully.");
        }

        [HttpDelete("admin/delete/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            await _productAppService.DeleteAsync(id);
            return Ok("Product deleted successfully.");
        }
    }
}
