using OnionSample.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnionSample.Domain.Interfaces
{
    public interface IProductService
    {
        Task<Product> GetByIdAsync(int id);
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> CreateProductAsync(Product product);
        Task UpdateProductForSellerAsync(Product product, int sellerId);
        Task UpdateProductForAdminAsync(Product product);
        Task<string> PurchaseProductAsync(int productId, int quantity);
    }
}
