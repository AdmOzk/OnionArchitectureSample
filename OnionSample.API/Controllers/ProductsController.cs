using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnionSample.Application.DTOs;
using OnionSample.Application.Interfaces;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Linq;

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

        // Seller: Create a product
        [HttpPost("seller/create")]
        [Authorize(Roles = "Seller")]
        public async Task<IActionResult> CreateProduct([FromBody] SellerProductDto dto)
        {
            // Retrieve sellerId from JWT claims.
            var sellerId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var productDto = new ProductDto
            {
                Title = dto.Title,
                Description = dto.Description,
                Image = dto.Image,
                Price = dto.Price,
                Stock = dto.Stock,
                SellerId = sellerId
            };

            var createdProduct = await _productAppService.CreateProductAsync(productDto);
            return Ok(createdProduct);
        }

        // Seller: Update his/her own product
        [HttpPut("seller/update")]
        [Authorize(Roles = "Seller")]
        public async Task<IActionResult> UpdateProductForSeller([FromBody] SellerProductDto dto)
        {
            var sellerId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            if (!dto.ProductId.HasValue)
                return BadRequest("ProductId is required for update.");

            var productDto = new ProductDto
            {
                ProductId = dto.ProductId.Value,
                Title = dto.Title,
                Description = dto.Description,
                Image = dto.Image,
                Price = dto.Price,
                Stock = dto.Stock
            };

            await _productAppService.UpdateProductForSellerAsync(productDto, sellerId);
            return Ok("Product updated successfully.");
        }

        // Admin: Update any product
        [HttpPut("admin/update")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateProductForAdmin([FromBody] AdminProductDto dto)
        {
            var productDto = new ProductDto
            {
                ProductId = dto.ProductId,
                Title = dto.Title,
                Description = dto.Description,
                Image = dto.Image,
                Price = dto.Price,
                Stock = dto.Stock,
                SellerId = dto.SellerId,
                Status = dto.Status
            };

            await _productAppService.UpdateProductForAdminAsync(productDto);
            return Ok("Product updated by admin.");
        }

        // Customer: Simulate purchase
        [HttpPost("customer/purchase")]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> PurchaseProduct([FromBody] PurchaseDto dto)
        {
            var result = await _productAppService.PurchaseProductAsync(dto.ProductId, dto.Quantity);
            return Ok(result);
        }

        // (Optional) Customer: Get all approved products.
        [HttpGet("customer/all")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllApprovedProducts()
        {
            var products = await _productAppService.GetAllProductsAsync();
            var approvedProducts = products.Where(p => p.Status.Equals("Approved", System.StringComparison.OrdinalIgnoreCase));
            return Ok(approvedProducts);
        }
    }
}
