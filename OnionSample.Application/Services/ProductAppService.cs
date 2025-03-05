using AutoMapper;
using OnionSample.Application.DTOs;
using OnionSample.Application.Interfaces;
using OnionSample.Domain.Entities;
using OnionSample.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnionSample.Application.Services
{
    public class ProductAppService : IProductAppService
    {
        // Use the domain service (business logic on domain entities)
        private readonly IProductService _domainProductService;
        private readonly IMapper _mapper;
        public ProductAppService(IProductService domainProductService, IMapper mapper)
        {
            _domainProductService = domainProductService;
            _mapper = mapper;
        }

        public async Task<ProductDto> CreateAsync(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            var created = await _domainProductService.CreateAsync(product);
            return _mapper.Map<ProductDto>(created);
        }

        public async Task DeleteAsync(int id)
        {
            await _domainProductService.DeleteAsync(id);
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var products = await _domainProductService.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<ProductDto> GetByIdAsync(int id)
        {
            var product = await _domainProductService.GetByIdAsync(id);
            return _mapper.Map<ProductDto>(product);
        }

        public async Task UpdateAsync(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            await _domainProductService.UpdateAsync(product);
        }
    }
}
