using OnionSample.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnionSample.Domain.Interfaces
{
    public interface IProductService
    {
        Task<Product> GetByIdAsync(int id);
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> CreateAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(int id);
    }
}
