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
        // This is the domain service (implementation in the Domain layer)
        private readonly IProductService _domainProductService;
        private readonly IMapper _mapper;
        public ProductAppService(IProductService domainProductService, IMapper mapper)
        {
            _domainProductService = domainProductService;
            _mapper = mapper;
        }

        public async Task<ProductDto> CreateProductAsync(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            var createdProduct = await _domainProductService.CreateProductAsync(product);
            return _mapper.Map<ProductDto>(createdProduct);
        }

        public async Task UpdateProductForSellerAsync(ProductDto productDto, int sellerId)
        {
            var product = _mapper.Map<Product>(productDto);
            await _domainProductService.UpdateProductForSellerAsync(product, sellerId);
        }

        public async Task UpdateProductForAdminAsync(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            await _domainProductService.UpdateProductForAdminAsync(product);
        }

        public async Task<string> PurchaseProductAsync(int productId, int quantity)
        {
            return await _domainProductService.PurchaseProductAsync(productId, quantity);
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            var products = await _domainProductService.GetAllProductsAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<ProductDto> GetByIdAsync(int id)
        {
            var product = await _domainProductService.GetByIdAsync(id);
            return _mapper.Map<ProductDto>(product);
        }
    }
}
