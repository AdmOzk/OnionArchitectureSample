using OnionSample.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnionSample.Application.Interfaces
{
    public interface IProductAppService
    {
        Task<ProductDto> GetByIdAsync(int id);
        Task<IEnumerable<ProductDto>> GetAllAsync();
        Task<ProductDto> CreateAsync(ProductDto productDto);
        Task UpdateAsync(ProductDto productDto);
        Task DeleteAsync(int id);
    }
}
