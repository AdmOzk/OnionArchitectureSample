using OnionSample.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnionSample.Application.Interfaces
{
    public interface IProductAppService
    {
        Task<ProductDto> GetByIdAsync(int id);
        Task<IEnumerable<ProductDto>> GetAllProductsAsync();
        Task<ProductDto> CreateProductAsync(ProductDto productDto);
        Task UpdateProductForSellerAsync(ProductDto productDto, int sellerId);
        Task UpdateProductForAdminAsync(ProductDto productDto);
        Task<string> PurchaseProductAsync(int productId, int quantity);
    }
}
